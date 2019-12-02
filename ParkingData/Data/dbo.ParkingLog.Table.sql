USE [parkdb]
GO

/****** Object:  Table [dbo].[ParkingLog]    Script Date: 12/1/2019 4:35:45 PM ******/
DROP TABLE [dbo].[ParkingLog]
GO

/****** Object:  Table [dbo].[ParkingLog]  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParkingLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LotKey] [varchar](50) NOT NULL,
	[ActionType] [varchar](50) NOT NULL,
	[ActionValue] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_ParkingLog] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ParkingLog] ADD  CONSTRAINT [DF_ParkingLog_ActionType]  DEFAULT ('notset') FOR [ActionType]
GO

ALTER TABLE [dbo].[ParkingLog] ADD  CONSTRAINT [DF_ParkingLog_ActionValue]  DEFAULT ((0)) FOR [ActionValue]
GO

ALTER TABLE [dbo].[ParkingLog] ADD  CONSTRAINT [DF_ParkingLog_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO