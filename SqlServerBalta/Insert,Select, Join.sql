CREATE TABLE [Categoria](
    [ID] INT IDENTITY(1,1),
    [NAME] VARCHAR(80) NOT NULL,
    

    CONSTRAINT [PK_Categoria] PRIMARY KEY([ID])
);

DROP TABLE [curso];
GO

CREATE TABLE [curso](
    [ID] INT IDENTITY(1,1),
    [NAME] VARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,

    CONSTRAINT [PK_CURSO] PRIMARY KEY([ID]),
    CONSTRAINT [FR_CategoryID] FOREIGN KEY([CategoriaId]) REFERENCES [Categoria]([ID])
);
GO

INSERT INTO [Categoria]([NAME]) VALUES('Backend');
INSERT INTO [Categoria]([NAME]) VALUES('Frontend');
INSERT INTO [Categoria]([NAME]) VALUES('Mobile');
GO

INSERT INTO [curso]([NAME],[Categoriaid]) VALUES('React.js', 4);
INSERT INTO [curso]([NAME],[Categoriaid]) VALUES('Node.js', 3);
INSERT INTO [curso]([NAME],[Categoriaid]) VALUES('React Native', 5);
GO

SELECT * FROM [curso];
SELECT * FROM [Categoria];

SELECT [curso].[ID] AS CURSO_ID, [curso].[NAME] as NOME_CURSO, [Categoria].[ID] AS CATEGORIA_ID, [Categoria].[NAME] as NOME_CATEGORIA
FROM [curso] LEFT JOIN [Categoria]
ON [Categoria].[ID] = [curso].[CategoriaId]

DELETE FROM [curso] WHERE [ID] = 4;
