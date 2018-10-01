USE [MemberDatabase]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2018/10/01 08:16:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[InternalMemberId] [int] IDENTITY(1,1) NOT NULL,
	[ExternalMemberId] [nvarchar](6) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Birthdate] [datetime] NOT NULL,
	[EligibilityStatus] [nvarchar](50) NOT NULL,
	[CoverageStart] [datetime] NOT NULL,
	[CoverageEnd] [datetime] NOT NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[InternalMemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
