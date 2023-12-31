
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Baskets]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Baskets](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Count] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Baskets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Blog]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Blog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tittle] [nvarchar](max) NULL,
	[Describtion] [nvarchar](max) NULL,
	[Owner] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[SoftDelete] [bit] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Blog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlogTag]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlogTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BlogId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_BlogTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
	[CategoryImage] [nvarchar](max) NULL,
	[SoftDelete] [bit] NOT NULL,
	[BackgroundColor] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Number] [nvarchar](max) NULL,
	[Context] [nvarchar](max) NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Offer]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Offer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Describtion] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Offer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[Describtion] [nvarchar](max) NULL,
	[Facebook] [nvarchar](max) NULL,
	[Twitter] [nvarchar](max) NULL,
	[TikTok] [nvarchar](max) NULL,
	[SoftDelete] [bit] NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Describtion] [nvarchar](max) NULL,
	[Count] [int] NOT NULL,
	[Raiting] [decimal](18, 2) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[InStock] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductImage]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[ProductId] [int] NOT NULL,
	[SoftDelete] [bit] NOT NULL,
	[IsMain] [bit] NOT NULL,
 CONSTRAINT [PK_ProductImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[Raiting] [int] NOT NULL,
	[Tittle] [nvarchar](max) NULL,
	[Describtion] [nvarchar](max) NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[SoftDelete] [bit] NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Username] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](max) NULL,
	[Tittle] [nvarchar](max) NULL,
	[Offer] [nvarchar](max) NULL,
	[Describtion] [nvarchar](max) NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tag]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TagName] [nvarchar](max) NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wishlist]    Script Date: 19.07.2023 15:31:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wishlist](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[SoftDelete] [bit] NOT NULL,
 CONSTRAINT [PK_Wishlist] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230706165328_CreateSliderTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230706185601_CreateProductTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230706194054_CreateProductTabless', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230706222145_UpdateProductImageTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707091621_CreateOfferTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707094127_CreateBlogTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707095438_RemoveBlogTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707101726_CreateBlogTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707102348_UpdateBlogTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707213441_UpdateProductTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230707213631_UpdateProductTablesAgain', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230709124147_PeopleTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230709133337_UpdatePersonTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230709174507_AccountTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230710113429_CreateBasketsTables', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230710212412_CreateReviewTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230710222500_UpdateReviewTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230710230623_AddRawToReviewTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230710230809_AddCreateDateToReviewTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230711175334_CreateWishlistTable', N'6.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230719105436_CreateContactTable', N'6.0.13')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1fc2d25d-f4ed-4968-9e9b-b55db7013903', N'SuperAdmin', N'SUPERADMIN', N'343a0e42-70f0-46bf-9105-263e24f85af2')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'36971cda-b55a-4025-b138-f8aebfa8e2a3', N'Admin', N'ADMIN', N'4518ea0c-eeab-4135-afb1-2e7f1a699971')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ae8f44f4-4e0f-4868-9e8d-0e48df71df8c', N'Member', N'MEMBER', N'49934904-6549-4bcd-90bb-ee7a30bdc7d3')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'baaaa2af-d541-4965-9f61-afd3a77e7bad', N'1fc2d25d-f4ed-4968-9e9b-b55db7013903')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'961e6915-fdf0-4f53-ac62-7a6f94323589', N'ae8f44f4-4e0f-4868-9e8d-0e48df71df8c')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'961e6915-fdf0-4f53-ac62-7a6f94323589', N'Parvin', N'Rehimli', N'Parvin123', N'PARVIN123', N'janegav379@miqlab.com', N'JANEGAV379@MIQLAB.COM', 1, N'AQAAAAEAACcQAAAAEISJ37CjPb4fNfwIeObwyYBW0Myd1e3WFjJv78BNTDY65Fd1c/5S3xBdyqpdFb8vpA==', N'LI2XOWOWN5JLQ2OADTMXGRJSOSFGYKJI', N'1535da25-ecff-4c62-9a41-0bd668eaa937', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FirstName], [LastName], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'baaaa2af-d541-4965-9f61-afd3a77e7bad', N'Mubariz', N'Agayev', N'Mubariz123', N'MUBARIZ123', N'kowir18566@nmaller.com', N'KOWIR18566@NMALLER.COM', 1, N'AQAAAAEAACcQAAAAEOAaI4i2gRzH62oXJXxM6p6/om+Lhf0jl8dm26sJi1nRzGwpVrdmgPvh8T+HUG12Ag==', N'ZNZTM35EZMNDU6PAXYVFVL3CCNYZGF3C', N'7f36ad67-ff84-4233-923e-a07e4bb4b281', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Blog] ON 

INSERT [dbo].[Blog] ([Id], [Tittle], [Describtion], [Owner], [CreateDate], [SoftDelete], [Image]) VALUES (1, N'Hundreds Of Professionals Across The World', N'Peachy Sangria wine is a light and fresh blend of award-winning St. James Winery Peach, Raspberry, and Moscato wines, and it has returned just in time for summertime sipping. In each bottle of Peachy Sangria, you’ll enjoy aromas and flavors of freshly sliced peaches and juicy Moscato with a touch of raspberry on the finish.', N'Apollo Theme', CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0, N'1.webp')
INSERT [dbo].[Blog] ([Id], [Tittle], [Describtion], [Owner], [CreateDate], [SoftDelete], [Image]) VALUES (2, N'Hundreds Of Professionals Across The World', N'Peachy Sangria wine is a light and fresh blend of award-winning St. James Winery Peach, Raspberry, and Moscato wines, and it has returned just in time for summertime sipping. In each bottle of Peachy Sangria, you’ll enjoy aromas and flavors of freshly sliced peaches and juicy Moscato with a touch of raspberry on the finish.', N'Apollo Theme', CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0, N'2.webp')
INSERT [dbo].[Blog] ([Id], [Tittle], [Describtion], [Owner], [CreateDate], [SoftDelete], [Image]) VALUES (3, N'Hundreds Of Professionals Across The World', N'Peachy Sangria wine is a light and fresh blend of award-winning St. James Winery Peach, Raspberry, and Moscato wines, and it has returned just in time for summertime sipping. In each bottle of Peachy Sangria, you’ll enjoy aromas and flavors of freshly sliced peaches and juicy Moscato with a touch of raspberry on the finish.', N'Apollo Theme', CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0, N'3.webp')
SET IDENTITY_INSERT [dbo].[Blog] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogTag] ON 

INSERT [dbo].[BlogTag] ([Id], [BlogId], [TagId], [SoftDelete]) VALUES (1, 1, 1, 0)
INSERT [dbo].[BlogTag] ([Id], [BlogId], [TagId], [SoftDelete]) VALUES (2, 1, 2, 0)
INSERT [dbo].[BlogTag] ([Id], [BlogId], [TagId], [SoftDelete]) VALUES (3, 2, 1, 0)
INSERT [dbo].[BlogTag] ([Id], [BlogId], [TagId], [SoftDelete]) VALUES (4, 2, 2, 0)
INSERT [dbo].[BlogTag] ([Id], [BlogId], [TagId], [SoftDelete]) VALUES (5, 3, 1, 0)
INSERT [dbo].[BlogTag] ([Id], [BlogId], [TagId], [SoftDelete]) VALUES (6, 3, 2, 0)
SET IDENTITY_INSERT [dbo].[BlogTag] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [CategoryName], [CategoryImage], [SoftDelete], [BackgroundColor]) VALUES (1, N'Whiskey', N'wine.png', 0, N'Whiskey-background.png')
INSERT [dbo].[Category] ([Id], [CategoryName], [CategoryImage], [SoftDelete], [BackgroundColor]) VALUES (2, N'Spirits', N'spirit.png', 0, N'Spirits-background.png')
INSERT [dbo].[Category] ([Id], [CategoryName], [CategoryImage], [SoftDelete], [BackgroundColor]) VALUES (3, N'Deals', N'Deals.png', 0, N'Deals-background.png')
INSERT [dbo].[Category] ([Id], [CategoryName], [CategoryImage], [SoftDelete], [BackgroundColor]) VALUES (4, N'Cognac', N'Cognac.png', 0, N'Cognac-background.png')
INSERT [dbo].[Category] ([Id], [CategoryName], [CategoryImage], [SoftDelete], [BackgroundColor]) VALUES (5, N'Cocktail', N'Cocktail.png', 0, N'Cocktail-background.png')
INSERT [dbo].[Category] ([Id], [CategoryName], [CategoryImage], [SoftDelete], [BackgroundColor]) VALUES (6, N'Beer', N'Beer.png', 0, N'Beer-background.png')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Offer] ON 

INSERT [dbo].[Offer] ([Id], [Describtion], [Image], [SoftDelete]) VALUES (1, N'<h4 style="font-weight: 700;color: white;">READY TO DRINK</h4>
                            <span style="color: white;">Price just</span><br>
                            <span style="color: red;font-weight:700;font-size:30px;">$49.90</span>', N'image_1_1920x.webp', 0)
INSERT [dbo].[Offer] ([Id], [Describtion], [Image], [SoftDelete]) VALUES (2, N'<h4 style="font-weight: 700;color: white;">FREE SHIPPING FREE GLASS</h4>
                            <span style="color: white;">With every purchase,</span><br>
                            <span style="color: white;">While stocks last.</span>', N'2.webp', 0)
INSERT [dbo].[Offer] ([Id], [Describtion], [Image], [SoftDelete]) VALUES (3, N'<h4 style="font-weight: 700;color: white;">TASTES GOOD</h4>
                            <span style="color: white;">Hotline Order</span><br>
                            <span style="color: red;font-weight:700;font-size:30px;">1 800 888 9999</span>', N'image_1_1920x.webp', 0)
INSERT [dbo].[Offer] ([Id], [Describtion], [Image], [SoftDelete]) VALUES (4, N'<h4 style="font-weight: 700;color: white;">SALE&OFFERS</h4>
                            <span style="color: white;">Use promocode sale25.</span><br>
                            <span style="color: white;">Hurry,end Sunday!</span>', N'4.webp', 0)
SET IDENTITY_INSERT [dbo].[Offer] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [Image], [Position], [Describtion], [Facebook], [Twitter], [TikTok], [SoftDelete], [Name]) VALUES (1, N'person1.png', N'CEO/FOUNDER', N'Lorem ipsum dolor sit, amet consectetur adipisicing elit. Velit dicta quasi illo officia obcaecati', N'https://www.facebook.com/', N'https://twitter.com/i/flow/login?redirect_after_login=%2F', N'https://www.tiktok.com/en/', 0, N'EMMA WATSON')
INSERT [dbo].[Person] ([Id], [Image], [Position], [Describtion], [Facebook], [Twitter], [TikTok], [SoftDelete], [Name]) VALUES (3, N'person2.png', N'CEO/FOUNDER', N'Lorem ipsum dolor sit, amet consectetur adipisicing elit. Velit dicta quasi illo officia obcaecati', N'https://www.facebook.com/', N'https://twitter.com/i/flow/login?redirect_after_login=%2F', N'https://www.tiktok.com/en/', 0, N'EMMA WATSON')
INSERT [dbo].[Person] ([Id], [Image], [Position], [Describtion], [Facebook], [Twitter], [TikTok], [SoftDelete], [Name]) VALUES (4, N'person3_1.png', N'CEO/FOUNDER', N'Lorem ipsum dolor sit, amet consectetur adipisicing elit. Velit dicta quasi illo officia obcaecati', N'https://www.facebook.com/', N'https://twitter.com/i/flow/login?redirect_after_login=%2F', N'https://www.tiktok.com/en/', 0, N'EMMA WATSON')
INSERT [dbo].[Person] ([Id], [Image], [Position], [Describtion], [Facebook], [Twitter], [TikTok], [SoftDelete], [Name]) VALUES (5, N'person4_1.png', N'CEO/FOUNDER', N'Lorem ipsum dolor sit, amet consectetur adipisicing elit. Velit dicta quasi illo officia obcaecati', N'https://www.facebook.com/', N'https://twitter.com/i/flow/login?redirect_after_login=%2F', N'https://www.tiktok.com/en/', 0, N'EMMA WATSON')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [Price], [Describtion], [Count], [Raiting], [CategoryId], [InStock], [CreateDate], [SoftDelete]) VALUES (1, N'Aerodynamic Linen Bench', CAST(110.00 AS Decimal(18, 2)), N'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla, provident dolorum. Temporibus dignissimos laboriosam minus illum itaque quisquam repellendus doloribus architecto, animi commodi molestias ab dolorum ea facere sequi! Dolor vitae fugiat ratione obcaecati sequi numquam minima non corrupti totam', 20, CAST(5.00 AS Decimal(18, 2)), 1, 1, CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Describtion], [Count], [Raiting], [CategoryId], [InStock], [CreateDate], [SoftDelete]) VALUES (2, N'Enermous Iron Gloves', CAST(120.00 AS Decimal(18, 2)), N'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla, provident dolorum. Temporibus dignissimos laboriosam minus illum itaque quisquam repellendus doloribus architecto, animi commodi molestias ab dolorum ea facere sequi! Dolor vitae fugiat ratione obcaecati sequi numquam minima non corrupti totam', 10, CAST(3.00 AS Decimal(18, 2)), 2, 1, CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Describtion], [Count], [Raiting], [CategoryId], [InStock], [CreateDate], [SoftDelete]) VALUES (3, N'Ergonomic Copper Shirt', CAST(72.00 AS Decimal(18, 2)), N'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla, provident dolorum. Temporibus dignissimos laboriosam minus illum itaque quisquam repellendus doloribus architecto, animi commodi molestias ab dolorum ea facere sequi! Dolor vitae fugiat ratione obcaecati sequi numquam minima non corrupti totam', 0, CAST(4.00 AS Decimal(18, 2)), 3, 0, CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Describtion], [Count], [Raiting], [CategoryId], [InStock], [CreateDate], [SoftDelete]) VALUES (4, N'Fantastic Leather Bench', CAST(82.00 AS Decimal(18, 2)), N'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla, provident dolorum. Temporibus dignissimos laboriosam minus illum itaque quisquam repellendus doloribus architecto, animi commodi molestias ab dolorum ea facere sequi! Dolor vitae fugiat ratione obcaecati sequi numquam minima non corrupti totam', 23, CAST(2.00 AS Decimal(18, 2)), 4, 1, CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Describtion], [Count], [Raiting], [CategoryId], [InStock], [CreateDate], [SoftDelete]) VALUES (5, N'Heavy Duty Concrecate Car', CAST(91.00 AS Decimal(18, 2)), N'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla, provident dolorum. Temporibus dignissimos laboriosam minus illum itaque quisquam repellendus doloribus architecto, animi commodi molestias ab dolorum ea facere sequi! Dolor vitae fugiat ratione obcaecati sequi numquam minima non corrupti totam', 10, CAST(3.50 AS Decimal(18, 2)), 5, 1, CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Describtion], [Count], [Raiting], [CategoryId], [InStock], [CreateDate], [SoftDelete]) VALUES (6, N'Incredible Granite Chair', CAST(80.00 AS Decimal(18, 2)), N'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla, provident dolorum. Temporibus dignissimos laboriosam minus illum itaque quisquam repellendus doloribus architecto, animi commodi molestias ab dolorum ea facere sequi! Dolor vitae fugiat ratione obcaecati sequi numquam minima non corrupti totam', 0, CAST(5.00 AS Decimal(18, 2)), 6, 0, CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0)
INSERT [dbo].[Product] ([Id], [Name], [Price], [Describtion], [Count], [Raiting], [CategoryId], [InStock], [CreateDate], [SoftDelete]) VALUES (7, N'Mediocre Granite Watch', CAST(110.00 AS Decimal(18, 2)), N'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Nulla, provident dolorum. Temporibus dignissimos laboriosam minus illum itaque quisquam repellendus doloribus architecto, animi commodi molestias ab dolorum ea facere sequi! Dolor vitae fugiat ratione obcaecati sequi numquam minima non corrupti totam', 18, CAST(4.00 AS Decimal(18, 2)), 3, 1, CAST(N'2022-04-22T10:34:23.0000000' AS DateTime2), 0)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductImage] ON 

INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (1, N'product-1 (2).webp', 1, 0, 1)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (2, N'product-1.webp', 1, 0, 0)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (3, N'product-2 (2).webp', 2, 0, 1)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (4, N'product-2.webp', 2, 0, 0)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (5, N'product-3.webp', 3, 0, 1)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (6, N'product-3-(2).webp', 3, 0, 0)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (7, N'product-4.webp', 4, 0, 1)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (8, N'product-4-(2).webp', 4, 0, 0)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (9, N'product-5.webp', 5, 0, 1)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (10, N'product-5-(2).webp', 5, 0, 0)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (11, N'product-6.webp', 6, 0, 1)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (12, N'product-6-(2).webp', 6, 0, 0)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (13, N'product-7.webp', 7, 0, 1)
INSERT [dbo].[ProductImage] ([Id], [Image], [ProductId], [SoftDelete], [IsMain]) VALUES (14, N'product-7-(2).webp', 7, 0, 0)
SET IDENTITY_INSERT [dbo].[ProductImage] OFF
GO
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([Id], [Image], [Tittle], [Offer], [Describtion], [SoftDelete]) VALUES (1, N'img1.webp', N'TOP SUMMER WINES', N'ANY 3 BOTTLES FOR ONLY $45.95', N'Taste them all and save with the collection', 0)
INSERT [dbo].[Sliders] ([Id], [Image], [Tittle], [Offer], [Describtion], [SoftDelete]) VALUES (2, N'img2.webp', N'TOP SUMMER WINES', N'ANY 3 BOTTLES FOR ONLY $45.95', N'Taste them all and save with the collection', 0)
SET IDENTITY_INSERT [dbo].[Sliders] OFF
GO
SET IDENTITY_INSERT [dbo].[Tag] ON 

INSERT [dbo].[Tag] ([Id], [TagName], [SoftDelete]) VALUES (1, N'TIPS & TRICK', 0)
INSERT [dbo].[Tag] ([Id], [TagName], [SoftDelete]) VALUES (2, N'VINEYARDS', 0)
SET IDENTITY_INSERT [dbo].[Tag] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 19.07.2023 15:31:58 ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 19.07.2023 15:31:58 ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Baskets_ProductId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_Baskets_ProductId] ON [dbo].[Baskets]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Baskets_UserId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_Baskets_UserId] ON [dbo].[Baskets]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogTag_BlogId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_BlogTag_BlogId] ON [dbo].[BlogTag]
(
	[BlogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_BlogTag_TagId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_BlogTag_TagId] ON [dbo].[BlogTag]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_CategoryId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_Product_CategoryId] ON [dbo].[Product]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductImage_ProductId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_ProductImage_ProductId] ON [dbo].[ProductImage]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reviews_ProductId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_ProductId] ON [dbo].[Reviews]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Reviews_UserId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_Reviews_UserId] ON [dbo].[Reviews]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Wishlist_ProductId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_Wishlist_ProductId] ON [dbo].[Wishlist]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Wishlist_UserId]    Script Date: 19.07.2023 15:31:58 ******/
CREATE NONCLUSTERED INDEX [IX_Wishlist_UserId] ON [dbo].[Wishlist]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ProductImage] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsMain]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Baskets]  WITH CHECK ADD  CONSTRAINT [FK_Baskets_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Baskets] CHECK CONSTRAINT [FK_Baskets_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Baskets]  WITH CHECK ADD  CONSTRAINT [FK_Baskets_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Baskets] CHECK CONSTRAINT [FK_Baskets_Product_ProductId]
GO
ALTER TABLE [dbo].[BlogTag]  WITH CHECK ADD  CONSTRAINT [FK_BlogTag_Blog_BlogId] FOREIGN KEY([BlogId])
REFERENCES [dbo].[Blog] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogTag] CHECK CONSTRAINT [FK_BlogTag_Blog_BlogId]
GO
ALTER TABLE [dbo].[BlogTag]  WITH CHECK ADD  CONSTRAINT [FK_BlogTag_Tag_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tag] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BlogTag] CHECK CONSTRAINT [FK_BlogTag_Tag_TagId]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category_CategoryId]
GO
ALTER TABLE [dbo].[ProductImage]  WITH CHECK ADD  CONSTRAINT [FK_ProductImage_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductImage] CHECK CONSTRAINT [FK_ProductImage_Product_ProductId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Reviews]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reviews] CHECK CONSTRAINT [FK_Reviews_Product_ProductId]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Wishlist]  WITH CHECK ADD  CONSTRAINT [FK_Wishlist_Product_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Wishlist] CHECK CONSTRAINT [FK_Wishlist_Product_ProductId]
GO

