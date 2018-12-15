CREATE TABLE [dbo].[ContactTag] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [ContactId] INT NOT NULL,
    [TagId]     INT NOT NULL,
    CONSTRAINT [PK_ContactTag] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ContactTag_Contact] FOREIGN KEY ([ContactId]) REFERENCES [dbo].[Contact] ([Id]),
    CONSTRAINT [FK_ContactTag_Tag] FOREIGN KEY ([TagId]) REFERENCES [dbo].[Tag] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_ContactTag_ByTag]
    ON [dbo].[ContactTag]([TagId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_ContactTag_ByContact]
    ON [dbo].[ContactTag]([ContactId] ASC);

