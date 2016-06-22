USE [$(DbName)];

CREATE TABLE [dbo].[EsendexDeliveryReceipts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [uniqueidentifier] NOT NULL,
	[MessageText] [nvarchar](max)
	[DeliveredAt] [DateTime2] NULL,
 CONSTRAINT [PK_EsendexDeliveryReceipts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

CREATE TABLE [dbo].[CollstreamDeliveryReceipts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [uniqueidentifier] NOT NULL,
	[DeliveredAt] [DateTime2] NULL,
 CONSTRAINT [PK_CollstreamDeliveryReceipts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

