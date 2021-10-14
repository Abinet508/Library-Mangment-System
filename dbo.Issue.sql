CREATE TABLE [dbo].[Issue] (
    [Student_Id]   INT         NOT NULL,
    [Student_Name] NCHAR (100) NOT NULL,
    [Book_Id]      INT         NOT NULL,
    [Book_Name]    NCHAR (100) NOT NULL,
    [Date]         TIME (7)    NOT NULL,
    PRIMARY KEY CLUSTERED ([Student_Id] ASC)
);

