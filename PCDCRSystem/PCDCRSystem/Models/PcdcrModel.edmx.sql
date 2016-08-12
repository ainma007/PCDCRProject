
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/12/2016 19:01:10
-- Generated from EDMX file: C:\Users\BlackSword\Documents\GitHub\PCDCRProject\PCDCRSystem\PCDCRSystem\Models\PcdcrModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PCDCR];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_City_Table_Province_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City_Table] DROP CONSTRAINT [FK_City_Table_Province_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_LogHistory_Users_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LogHistory] DROP CONSTRAINT [FK_LogHistory_Users_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectActivities_Table_ActivitiesCategory_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectActivities_Table] DROP CONSTRAINT [FK_ProjectActivities_Table_ActivitiesCategory_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectActivities_Table_ActivityPeopleCategory_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectActivities_Table] DROP CONSTRAINT [FK_ProjectActivities_Table_ActivityPeopleCategory_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectActivities_Table_City_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectActivities_Table] DROP CONSTRAINT [FK_ProjectActivities_Table_City_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectActivities_Table_Corporation_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectActivities_Table] DROP CONSTRAINT [FK_ProjectActivities_Table_Corporation_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectActivities_Table_Projects_table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectActivities_Table] DROP CONSTRAINT [FK_ProjectActivities_Table_Projects_table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectActivities_Table_Province_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectActivities_Table] DROP CONSTRAINT [FK_ProjectActivities_Table_Province_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectActivities_Table_Users_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectActivities_Table] DROP CONSTRAINT [FK_ProjectActivities_Table_Users_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectControl_Projects_table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectControl_table] DROP CONSTRAINT [FK_ProjectControl_Projects_table];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectControl_Users_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectControl_table] DROP CONSTRAINT [FK_ProjectControl_Users_Table];
GO
IF OBJECT_ID(N'[dbo].[FK_Projects_table_Programs_Table]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects_table] DROP CONSTRAINT [FK_Projects_table_Programs_Table];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ActivitiesCategory_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivitiesCategory_Table];
GO
IF OBJECT_ID(N'[dbo].[ActivityPeopleCategory_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivityPeopleCategory_Table];
GO
IF OBJECT_ID(N'[dbo].[City_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City_Table];
GO
IF OBJECT_ID(N'[dbo].[Corporation_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Corporation_Table];
GO
IF OBJECT_ID(N'[dbo].[LogHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogHistory];
GO
IF OBJECT_ID(N'[dbo].[Programs_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Programs_Table];
GO
IF OBJECT_ID(N'[dbo].[ProjectActivities_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectActivities_Table];
GO
IF OBJECT_ID(N'[dbo].[ProjectControl_table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectControl_table];
GO
IF OBJECT_ID(N'[dbo].[Projects_table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects_table];
GO
IF OBJECT_ID(N'[dbo].[Province_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Province_Table];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Users_Table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users_Table];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ActivitiesCategory_Table'
CREATE TABLE [dbo].[ActivitiesCategory_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ActivitiesCategoryName] nvarchar(50)  NULL
);
GO

-- Creating table 'City_Table'
CREATE TABLE [dbo].[City_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CityName] nvarchar(50)  NULL,
    [ProvinceID] int  NULL
);
GO

-- Creating table 'Corporation_Table'
CREATE TABLE [dbo].[Corporation_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [CorporationName] nvarchar(100)  NULL,
    [CorporationPhone] nvarchar(50)  NULL,
    [CorporationAddress] nvarchar(100)  NULL
);
GO

-- Creating table 'Programs_Table'
CREATE TABLE [dbo].[Programs_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProgramName] nvarchar(50)  NULL
);
GO

-- Creating table 'ProjectActivities_Table'
CREATE TABLE [dbo].[ProjectActivities_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [Srarttime] time  NULL,
    [EndTime] time  NULL,
    [ActivitiesCategoryID] int  NULL,
    [ActivityPeopleCategory] int  NULL,
    [ProvinceID] int  NULL,
    [CityID] int  NULL,
    [CorporationID] int  NULL,
    [ActivatorName] nvarchar(50)  NULL,
    [ActivatorMobil] nvarchar(50)  NULL,
    [CorporationContactRing] nvarchar(50)  NULL,
    [CorporationPhone] nvarchar(50)  NULL,
    [TotalPresence] int  NULL,
    [TotalMale] int  NULL,
    [TotlFemal] int  NULL,
    [Emergency_Intervention] nchar(10)  NULL,
    [ProjectID] int  NULL,
    [UserID] int  NULL,
    [SaturdayDay] bit  NULL,
    [SundayDay] bit  NULL,
    [MondayDay] bit  NULL,
    [tuesdayDay] bit  NULL,
    [wednesdayDay] bit  NULL,
    [thursdayDay] bit  NULL
);
GO

-- Creating table 'Projects_table'
CREATE TABLE [dbo].[Projects_table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(50)  NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [ProjectStatus] bit  NOT NULL,
    [ProgrameID] int  NULL
);
GO

-- Creating table 'Province_Table'
CREATE TABLE [dbo].[Province_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ProvinceName] nvarchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'ProjectControl_table'
CREATE TABLE [dbo].[ProjectControl_table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NULL,
    [ProjectID] int  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'Users_Table'
CREATE TABLE [dbo].[Users_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [FullName] nvarchar(100)  NULL,
    [UserName] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [UserType] nvarchar(50)  NULL,
    [UserPhone] nvarchar(50)  NULL,
    [UserAddress] nvarchar(max)  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'ActivityPeopleCategory_Table'
CREATE TABLE [dbo].[ActivityPeopleCategory_Table] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PeopleCategoryName] nvarchar(50)  NULL
);
GO

-- Creating table 'LogHistory'
CREATE TABLE [dbo].[LogHistory] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [LogInTime] datetime  NULL,
    [LogOutTime] datetime  NULL,
    [Status] nvarchar(10)  NULL,
    [IPAddress] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'ActivitiesCategory_Table'
ALTER TABLE [dbo].[ActivitiesCategory_Table]
ADD CONSTRAINT [PK_ActivitiesCategory_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'City_Table'
ALTER TABLE [dbo].[City_Table]
ADD CONSTRAINT [PK_City_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Corporation_Table'
ALTER TABLE [dbo].[Corporation_Table]
ADD CONSTRAINT [PK_Corporation_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Programs_Table'
ALTER TABLE [dbo].[Programs_Table]
ADD CONSTRAINT [PK_Programs_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [PK_ProjectActivities_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Projects_table'
ALTER TABLE [dbo].[Projects_table]
ADD CONSTRAINT [PK_Projects_table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Province_Table'
ALTER TABLE [dbo].[Province_Table]
ADD CONSTRAINT [PK_Province_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [ID] in table 'ProjectControl_table'
ALTER TABLE [dbo].[ProjectControl_table]
ADD CONSTRAINT [PK_ProjectControl_table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users_Table'
ALTER TABLE [dbo].[Users_Table]
ADD CONSTRAINT [PK_Users_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActivityPeopleCategory_Table'
ALTER TABLE [dbo].[ActivityPeopleCategory_Table]
ADD CONSTRAINT [PK_ActivityPeopleCategory_Table]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'LogHistory'
ALTER TABLE [dbo].[LogHistory]
ADD CONSTRAINT [PK_LogHistory]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ActivitiesCategoryID] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [FK_ProjectActivities_Table_ActivitiesCategory_Table]
    FOREIGN KEY ([ActivitiesCategoryID])
    REFERENCES [dbo].[ActivitiesCategory_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActivities_Table_ActivitiesCategory_Table'
CREATE INDEX [IX_FK_ProjectActivities_Table_ActivitiesCategory_Table]
ON [dbo].[ProjectActivities_Table]
    ([ActivitiesCategoryID]);
GO

-- Creating foreign key on [ProvinceID] in table 'City_Table'
ALTER TABLE [dbo].[City_Table]
ADD CONSTRAINT [FK_City_Table_Province_Table]
    FOREIGN KEY ([ProvinceID])
    REFERENCES [dbo].[Province_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_City_Table_Province_Table'
CREATE INDEX [IX_FK_City_Table_Province_Table]
ON [dbo].[City_Table]
    ([ProvinceID]);
GO

-- Creating foreign key on [CityID] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [FK_ProjectActivities_Table_City_Table]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[City_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActivities_Table_City_Table'
CREATE INDEX [IX_FK_ProjectActivities_Table_City_Table]
ON [dbo].[ProjectActivities_Table]
    ([CityID]);
GO

-- Creating foreign key on [CorporationID] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [FK_ProjectActivities_Table_Corporation_Table]
    FOREIGN KEY ([CorporationID])
    REFERENCES [dbo].[Corporation_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActivities_Table_Corporation_Table'
CREATE INDEX [IX_FK_ProjectActivities_Table_Corporation_Table]
ON [dbo].[ProjectActivities_Table]
    ([CorporationID]);
GO

-- Creating foreign key on [ProgrameID] in table 'Projects_table'
ALTER TABLE [dbo].[Projects_table]
ADD CONSTRAINT [FK_Projects_table_Programs_Table]
    FOREIGN KEY ([ProgrameID])
    REFERENCES [dbo].[Programs_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Projects_table_Programs_Table'
CREATE INDEX [IX_FK_Projects_table_Programs_Table]
ON [dbo].[Projects_table]
    ([ProgrameID]);
GO

-- Creating foreign key on [ProjectID] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [FK_ProjectActivities_Table_Projects_table]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects_table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActivities_Table_Projects_table'
CREATE INDEX [IX_FK_ProjectActivities_Table_Projects_table]
ON [dbo].[ProjectActivities_Table]
    ([ProjectID]);
GO

-- Creating foreign key on [ProvinceID] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [FK_ProjectActivities_Table_Province_Table]
    FOREIGN KEY ([ProvinceID])
    REFERENCES [dbo].[Province_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActivities_Table_Province_Table'
CREATE INDEX [IX_FK_ProjectActivities_Table_Province_Table]
ON [dbo].[ProjectActivities_Table]
    ([ProvinceID]);
GO

-- Creating foreign key on [UserID] in table 'ProjectControl_table'
ALTER TABLE [dbo].[ProjectControl_table]
ADD CONSTRAINT [FK_ProjectControl_Programs_Table]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Programs_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectControl_Programs_Table'
CREATE INDEX [IX_FK_ProjectControl_Programs_Table]
ON [dbo].[ProjectControl_table]
    ([UserID]);
GO

-- Creating foreign key on [ProjectID] in table 'ProjectControl_table'
ALTER TABLE [dbo].[ProjectControl_table]
ADD CONSTRAINT [FK_ProjectControl_Projects_table]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects_table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectControl_Projects_table'
CREATE INDEX [IX_FK_ProjectControl_Projects_table]
ON [dbo].[ProjectControl_table]
    ([ProjectID]);
GO

-- Creating foreign key on [UserID] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [FK_ProjectActivities_Table_Users_Table]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActivities_Table_Users_Table'
CREATE INDEX [IX_FK_ProjectActivities_Table_Users_Table]
ON [dbo].[ProjectActivities_Table]
    ([UserID]);
GO

-- Creating foreign key on [UserID] in table 'ProjectControl_table'
ALTER TABLE [dbo].[ProjectControl_table]
ADD CONSTRAINT [FK_ProjectControl_Users_Table]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectControl_Users_Table'
CREATE INDEX [IX_FK_ProjectControl_Users_Table]
ON [dbo].[ProjectControl_table]
    ([UserID]);
GO

-- Creating foreign key on [ActivityPeopleCategory] in table 'ProjectActivities_Table'
ALTER TABLE [dbo].[ProjectActivities_Table]
ADD CONSTRAINT [FK_ProjectActivities_Table_ActivityPeopleCategory_Table]
    FOREIGN KEY ([ActivityPeopleCategory])
    REFERENCES [dbo].[ActivityPeopleCategory_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectActivities_Table_ActivityPeopleCategory_Table'
CREATE INDEX [IX_FK_ProjectActivities_Table_ActivityPeopleCategory_Table]
ON [dbo].[ProjectActivities_Table]
    ([ActivityPeopleCategory]);
GO

-- Creating foreign key on [UserId] in table 'LogHistory'
ALTER TABLE [dbo].[LogHistory]
ADD CONSTRAINT [FK_LogHistory_Users_Table]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users_Table]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogHistory_Users_Table'
CREATE INDEX [IX_FK_LogHistory_Users_Table]
ON [dbo].[LogHistory]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------