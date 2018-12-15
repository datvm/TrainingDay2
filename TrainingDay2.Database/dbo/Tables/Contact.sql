CREATE TABLE [dbo].[Contact] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (100) NULL,
    [LastName]    NVARCHAR (100) NULL,
    [JobTitle]    NVARCHAR (100) NULL,
    [Company]     NVARCHAR (100) NULL,
    [PhoneNumber] VARCHAR (20)   NULL,
    [Email]       NVARCHAR (255) NULL,
    [Skype]       NVARCHAR (255) NULL,
    [LinkedIn]    NVARCHAR (255) NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Contact_FirstName]
    ON [dbo].[Contact]([FirstName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Contact_LastName]
    ON [dbo].[Contact]([LastName] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Contact_Company]
    ON [dbo].[Contact]([Company] ASC);

