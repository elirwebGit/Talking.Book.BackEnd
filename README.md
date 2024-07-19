# Talking.Book.BackEnd

# Script de base de dados
--create database TalkingBoook
go


create table  Livro
(
Codigo int identity primary key,
Titulo varchar(30),
Autor varchar(30),
Lancamento datetime
)
go

 create table LivroDigital
(
Codigo int identity primary key, 
LivroId int FOREIGN KEY REFERENCES Livro(Codigo) 
)
go
create table LivroImpressao
(
Codigo int identity primary key,
LivroId int FOREIGN KEY REFERENCES Livro(Codigo) 
)

go
create table Tag 
(
Codigo int identity primary key,
Descricao varchar(100),
LivroId int FOREIGN KEY REFERENCES Livro(Codigo) 
)

go
create table TipoEncadernacao
(
Codigo int identity primary key,
Nome varchar(50),
Descricao varchar(50),
Formato varchar(50),
LivroImpressaoId int FOREIGN KEY REFERENCES LivroImpressao(Codigo) 
)

-- como executar a procedure
EXEC SP_GetAllLivro @mes = 08;
go
CREATE OR ALTER PROCEDURE sp_GetAllBooks
    @ano INT = NULL,
    @mes INT = NULL,
    @anoLancamento DATETIME = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Base query
    DECLARE @sql NVARCHAR(MAX);
    SET @sql = '
        SELECT 
            liv.codigo, 
            liv.Titulo, 
            liv.Autor, 
            liv.Lancamento, 
            tag.Descricao 
        FROM Livro liv
        left JOIN LivroDigital livD ON livD.LivroId = liv.Codigo
        left JOIN LivroImpressao livImp ON livImp.LivroId = liv.Codigo  
        INNER JOIN Tag tag ON tag.LivroId = liv.Codigo
        WHERE 1 = 1'; 

    -- Append conditions dynamically
    IF @ano IS NOT NULL
    BEGIN
        SET @sql = @sql + ' AND DATEPART(YEAR,  liv.Lancamento) = @ano';
    END

    IF @mes IS NOT NULL
    BEGIN
	print @mes
        SET @sql = @sql + ' AND DATEPART(MONTH, ''2024-07-19'') = @mes';
    END

    IF @anoLancamento IS NOT NULL
    BEGIN
        SET @sql = @sql + ' AND CAST(liv.Lancamento AS DATE) = CAST(@anoLancamento AS DATE)';
    END

    -- Debugging: Print the dynamic SQL to check the query
    PRINT @sql;

    -- Execute the dynamic SQL
    EXEC sp_executesql 
        @sql,
        N'@ano INT, @mes INT, @anoLancamento DATETIME',
        @ano = @ano,
        @mes = @mes,
        @anoLancamento = @anoLancamento;
END

go

 CREATE or alter PROCEDURE sp_AddBook
    @Titulo NVARCHAR(100),
    @Autor NVARCHAR(100),
    @Lancamento datetime,
	@TipoLivro varchar(20),
	@Descricao varchar(50)
AS
BEGIN
    INSERT INTO Livro (Titulo, Autor, Lancamento) VALUES (@Titulo, @Autor, @Lancamento)
	INSERT INTO Tag(Descricao,LivroId) VALUES (@Descricao,SCOPE_IDENTITY())

	IF @TipoLivro = 'impresso'
		INSERT INTO LivroImpressao (LivroId) VALUES (SCOPE_IDENTITY())
	IF @TipoLivro = 'digital'
		INSERT INTO LivroDigital (LivroId) VALUES (SCOPE_IDENTITY())
	
END



SELECT * FROM Livro where DATEPART(YEAR,'2024-07-19')= 2024
EXEC sp_GetAllBooks  @mes = 7;




