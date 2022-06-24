CREATE TABLE [dbo].[StorageAsset] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [StorageId]  INT      NOT NULL,
    [AssetId]    INT      NOT NULL,
    [Volume]     INT      NOT NULL,
    [IncomeDate] DATETIME NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_StorageAsset_AssetId] FOREIGN KEY ([AssetId]) REFERENCES [dbo].[Asset] ([Id]),
    CONSTRAINT [FK_StorageAsset_StorageId] FOREIGN KEY ([StorageId]) REFERENCES [dbo].[Storage] ([Id])
);

