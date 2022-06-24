CREATE TABLE [dbo].[Asset] (
    [Id]                INT           IDENTITY (1, 1) NOT NULL,
    [AssetName]         VARCHAR (200) NOT NULL,
    [StorageType]       VARCHAR (200) NOT NULL,
    [SquareMeterVolume] INT           NOT NULL,
    [ExpirationDays]    INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

