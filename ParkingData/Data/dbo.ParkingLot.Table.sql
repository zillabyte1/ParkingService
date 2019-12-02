USE [parkdb]
GO

/****** Object:  Table [dbo].[ParkingLot]    Script Date: 11/24/2019 11:09:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ParkingLot](
	[LotKey] [varchar](50) NOT NULL,
	[MaxSpaces] [int] NOT NULL,
	[Occupied] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
 CONSTRAINT [PK_ParkingLot] PRIMARY KEY CLUSTERED 
(
	[LotKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ParkingLot] ADD  CONSTRAINT [DF_ParkingLot_MaxSpaces]  DEFAULT ((0)) FOR [MaxSpaces]
GO

ALTER TABLE [dbo].[ParkingLot] ADD  CONSTRAINT [DF_ParkingLot_Occupied]  DEFAULT ((0)) FOR [Occupied]
GO

ALTER TABLE [dbo].[ParkingLot] ADD  CONSTRAINT [DF_ParkingLot_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
