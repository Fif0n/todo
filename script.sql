USE [todo]
GO
/****** Object:  Table [dbo].[todo]    Script Date: 08.04.2023 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[todo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[content] [text] NOT NULL,
	[dateAdd] [int] NOT NULL,
	[priority] [int] NOT NULL,
	[done] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
