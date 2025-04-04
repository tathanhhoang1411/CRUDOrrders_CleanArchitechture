﻿USE [CRUDOrders]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 2025-03-24 오전 3:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[ProductName] [nvarchar](255) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK__OrderDet__3214EC07406473A7] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2025-03-24 오전 3:25:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](255) NOT NULL,
	[TotalAmount] [decimal](18, 2) NOT NULL,
	[Status] [int] NOT NULL,
	[CreateAt] [datetime] NOT NULL,
	[UpdatedAt] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK__OrderDeta__Order__3A81B327] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK__OrderDeta__Order__3A81B327]
GO


INSERT INTO [dbo].[Orders] (CustomerName, TotalAmount, Status, CreateAt, UpdatedAt)
VALUES 
('Nguyễn Văn A', 150.00, 1, GETDATE(), GETDATE()),
('Trần Thị B', 200.50, 1, GETDATE(), GETDATE()),
('Lê Văn C', 300.75, 2, GETDATE(), GETDATE()),
('Phạm Thị D', 400.00, 1, GETDATE(), GETDATE()),
('Nguyễn Văn E', 250.00, 3, GETDATE(), GETDATE()),
('Trần Văn F', 180.25, 1, GETDATE(), GETDATE()),
('Lê Thị G', 320.00, 2, GETDATE(), GETDATE()),
('Phạm Văn H', 275.50, 1, GETDATE(), GETDATE()),
('Nguyễn Thị I', 450.00, 3, GETDATE(), GETDATE()),
('Trần Văn J', 600.00, 1, GETDATE(), GETDATE());

INSERT INTO [dbo].[OrderDetails] (OrderId, ProductName, Quantity, Price)
VALUES 
(1, 'Sản phẩm A', 2, 75.00),
(1, 'Sản phẩm B', 1, 50.00),
(2, 'Sản phẩm C', 3, 66.83),
(2, 'Sản phẩm D', 1, 133.67),
(3, 'Sản phẩm E', 5, 60.15),
(4, 'Sản phẩm F', 2, 200.00),
(5, 'Sản phẩm G', 1, 250.00),
(6, 'Sản phẩm H', 4, 45.06),
(7, 'Sản phẩm I', 3, 106.67),
(8, 'Sản phẩm J', 1, 275.50);
