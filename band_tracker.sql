USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 12/15/2016 6:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 12/15/2016 6:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 12/15/2016 6:52:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[venue_name] [varchar](255) NULL
) ON [PRIMARY]

GO
