CREATE TABLE [dbo].[Admin] (
    [Admin_Id]       INT            NOT NULL,
    [Admin_Name]     NVARCHAR (100) NOT NULL,
    [Admin_Email]    NCHAR (100)    NOT NULL,
    [Admin_Phone]    INT            NOT NULL,
    [Admin_Password] NCHAR (100)    NOT NULL,
    [Admin_Photo]    NVARCHAR(50)          NOT NULL,
    PRIMARY KEY CLUSTERED ([Admin_Id] ASC)
);

