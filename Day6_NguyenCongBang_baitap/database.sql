-- Script tạo cơ sở dữ liệu và bảng cho bài tập Movie - Genre
IF OBJECT_ID(N'[Genre]', 'U') IS NULL
BEGIN
    CREATE TABLE [Genre] (
        [Id] int NOT NULL IDENTITY(1,1),
        [Name] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Genre] PRIMARY KEY ([Id])
    );
END;
GO

IF OBJECT_ID(N'[Movie]', 'U') IS NULL
BEGIN
    CREATE TABLE [Movie] (
        [Id] int NOT NULL IDENTITY(1,1),
        [Title] nvarchar(200) NOT NULL,
        [ReleaseDate] datetime2 NOT NULL,
        [Duration] int NOT NULL,
        [GenreId] int NOT NULL,
        CONSTRAINT [PK_Movie] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Movie_Genre_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genre] ([Id]) ON DELETE CASCADE
    );

    CREATE INDEX [IX_Movie_GenreId] ON [Movie] ([GenreId]);
END;
GO

-- Chèn dữ liệu mẫu giống như trên bảng cô giáo
SET IDENTITY_INSERT [Genre] ON;
IF NOT EXISTS (SELECT 1 FROM [Genre] WHERE [Id] = 1)
    INSERT INTO [Genre] ([Id], [Name]) VALUES (1, N'Hành động');
IF NOT EXISTS (SELECT 1 FROM [Genre] WHERE [Id] = 2)
    INSERT INTO [Genre] ([Id], [Name]) VALUES (2, N'Hoạt hình');
IF NOT EXISTS (SELECT 1 FROM [Genre] WHERE [Id] = 3)
    INSERT INTO [Genre] ([Id], [Name]) VALUES (3, N'Kinh dị');
IF NOT EXISTS (SELECT 1 FROM [Genre] WHERE [Id] = 4)
    INSERT INTO [Genre] ([Id], [Name]) VALUES (4, N'Hài kịch');
SET IDENTITY_INSERT [Genre] OFF;
GO

SET IDENTITY_INSERT [Movie] ON;
IF NOT EXISTS (SELECT 1 FROM [Movie] WHERE [Id] = 1)
    INSERT INTO [Movie] ([Id], [Title], [ReleaseDate], [Duration], [GenreId]) 
    VALUES (1, N'James Bond', '2026-01-01', 120, 1);

IF NOT EXISTS (SELECT 1 FROM [Movie] WHERE [Id] = 2)
    INSERT INTO [Movie] ([Id], [Title], [ReleaseDate], [Duration], [GenreId]) 
    VALUES (2, N'Doraemon', '2000-01-01', 90, 2);
SET IDENTITY_INSERT [Movie] OFF;
GO
