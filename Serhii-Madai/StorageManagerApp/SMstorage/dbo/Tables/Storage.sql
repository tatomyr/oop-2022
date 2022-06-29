CREATE TABLE [dbo].[Storage] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [StorageName]     VARCHAR (200) NOT NULL,
    [DryStorageSpace] INT           NOT NULL,
    [HotStorageSpace] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

