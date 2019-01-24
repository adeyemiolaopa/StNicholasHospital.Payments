USE [master]
GO
/****** Object:  Database [stnicholas-payment-db]    Script Date: 05/01/2019 01:19:03 ******/
CREATE DATABASE [stnicholas-payment-db] ON  PRIMARY 
( NAME = N'stnicholas-payment-db', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\stnicholas-payment-db.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'stnicholas-payment-db_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\stnicholas-payment-db_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [stnicholas-payment-db].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [stnicholas-payment-db] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET ARITHABORT OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [stnicholas-payment-db] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [stnicholas-payment-db] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET  DISABLE_BROKER 
GO
ALTER DATABASE [stnicholas-payment-db] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [stnicholas-payment-db] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [stnicholas-payment-db] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [stnicholas-payment-db] SET  MULTI_USER 
GO
ALTER DATABASE [stnicholas-payment-db] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [stnicholas-payment-db] SET DB_CHAINING OFF 
GO
USE [stnicholas-payment-db]
GO
/****** Object:  Table [dbo].[Patients]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Patients](
	[PatientID] [varchar](36) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](15) NOT NULL,
	[Email] [varchar](50) NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[TotalPayment] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentID] [varchar](36) NOT NULL,
	[PatientID] [varchar](36) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Amount] [decimal](18, 0) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[PaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Staff]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Staff](
	[StaffID] [varchar](50) NOT NULL,
	[StaffNo] [uniqueidentifier] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[Firstname] [varchar](50) NOT NULL,
	[Lastname] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](15) NULL,
	[Password] [varchar](50) NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[StaffID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Patients] ([PatientID], [EntryDate], [Firstname], [Lastname], [PhoneNo], [Email], [CreatedBy], [TotalPayment]) VALUES (N'3c0bc425-3ea8-4579-8147-2a99f987b048', CAST(N'2019-01-02 14:02:14.847' AS DateTime), N'Fisayo', N'Olusoji', N'08067564565', N'fisayoolusoji@gmail.com', N'SYSTEM', NULL)
GO
INSERT [dbo].[Patients] ([PatientID], [EntryDate], [Firstname], [Lastname], [PhoneNo], [Email], [CreatedBy], [TotalPayment]) VALUES (N'a662dec0-4641-4fac-92c3-c59b588bedfd', CAST(N'2019-01-04 15:30:17.633' AS DateTime), N'Adeyemi', N'Olaopa', N'08034556781', N'adeyemiolaopa@gmail.com', N'SYSTEM', NULL)
GO
INSERT [dbo].[Patients] ([PatientID], [EntryDate], [Firstname], [Lastname], [PhoneNo], [Email], [CreatedBy], [TotalPayment]) VALUES (N'd6030ca6-8ab0-4b75-9e2f-3f0cbd7a4e68', CAST(N'2019-01-02 14:08:45.203' AS DateTime), N'Babajide', N'Awotunde', N'08054673366', N'babajideawotunde@gmail.com', N'SYSTEM', NULL)
GO
INSERT [dbo].[Patients] ([PatientID], [EntryDate], [Firstname], [Lastname], [PhoneNo], [Email], [CreatedBy], [TotalPayment]) VALUES (N'e7112286-f0a0-4310-919b-36226ed5ce6f', CAST(N'2019-01-02 01:34:42.337' AS DateTime), N'Folarin', N'Awotunde', N'08054676575', N'folarinawotunde@gmail.com', N'SYSTEM', NULL)
GO
INSERT [dbo].[Payments] ([PaymentID], [PatientID], [Description], [EntryDate], [Amount], [CreatedBy]) VALUES (N'7eabe52b-bd64-4689-a18b-fea25174af2e', N'390b4bd7-680c-4842-a5e7-3699315f5e96', N'Just testing the payment module', CAST(N'2019-01-04 00:00:00.000' AS DateTime), CAST(700 AS Decimal(18, 0)), N'SYSTEM')
GO
INSERT [dbo].[Payments] ([PaymentID], [PatientID], [Description], [EntryDate], [Amount], [CreatedBy]) VALUES (N'9c7b79b8-0377-4be9-b6da-3854271f1523', N'e7112286-f0a0-4310-919b-36226ed5ce6f', N'Just testing the payment module', CAST(N'2019-01-04 00:00:00.000' AS DateTime), CAST(3232 AS Decimal(18, 0)), N'SYSTEM')
GO
INSERT [dbo].[Staff] ([StaffID], [StaffNo], [EntryDate], [Firstname], [Lastname], [PhoneNo], [Password], [CreatedBy]) VALUES (N'adeyemiolaopa@gmail.com', N'd5464c9b-7029-463f-a35d-05d0b523b5c5', CAST(N'2018-12-31 00:00:00.000' AS DateTime), N'Adeyemi', N'Olaopa', N'09087675654', N'123456', N'SYSTEM')
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Patients]    Script Date: 05/01/2019 01:19:04 ******/
ALTER TABLE [dbo].[Patients] ADD  CONSTRAINT [IX_Patients] UNIQUE NONCLUSTERED 
(
	[PhoneNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[stpGetAllPatients]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018  
-- Description: Return all patients  
-- =============================================  
--Store procedure name is --> stpGetAllPatients  
CREATE PROCEDURE [dbo].[stpGetAllPatients]
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
    Select * from Patients
END  

GO
/****** Object:  StoredProcedure [dbo].[stpGetAllStaff]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 04-Jan-2019
-- Description: Return all staff members  
-- =============================================  
--Store procedure name is --> stpGetAllStaff  
CREATE PROCEDURE [dbo].[stpGetAllStaff]
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
    Select * from Staff
END  

GO
/****** Object:  StoredProcedure [dbo].[stpGetPatientByPatientID]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018  
-- Description: Return specific patient record 
-- =============================================  
CREATE PROCEDURE [dbo].[stpGetPatientByPatientID] 
    -- Add the parameters for the stored procedure here  
    @PatientID varchar(36)
      
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Select * From Patients   
    where PatientID = @PatientID
          
END  

GO
/****** Object:  StoredProcedure [dbo].[stpGetPatientByPhoneNo]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018  
-- Description: Return specific patient record 
-- =============================================  
CREATE PROCEDURE [dbo].[stpGetPatientByPhoneNo] 
    -- Add the parameters for the stored procedure here  
    @PhoneNo varchar(30)
      
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Select * From Patients   
    where PhoneNo = @PhoneNo
          
END  

GO
/****** Object:  StoredProcedure [dbo].[stpGetPaymentByPaymentID]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018   
-- Description: Return specific payment record 
-- =============================================  
CREATE PROCEDURE [dbo].[stpGetPaymentByPaymentID]  
    -- Add the parameters for the stored procedure here  
    @PaymentID varchar(36)
      
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Select * From Payments   
    where PaymentID = @PaymentID  
          
END

GO
/****** Object:  StoredProcedure [dbo].[stpGetPaymentsByPatientID]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa 
-- Create Date: 22-Dec-2018  
-- Description: Return specific payment records  
-- =============================================  
CREATE PROCEDURE [dbo].[stpGetPaymentsByPatientID] 
    -- Add the parameters for the stored procedure here  
    @PatientID varchar(36)
      
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Select * From Payments   
    where PatientID = @PatientID
          
END  

GO
/****** Object:  StoredProcedure [dbo].[stpGetStaffByStaffID]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018   
-- Description: Return specific staff record 
-- =============================================  
CREATE PROCEDURE [dbo].[stpGetStaffByStaffID]  
    -- Add the parameters for the stored procedure here  
    @StaffID varchar(30),  @Password varchar(30)
      
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Select * From Staff   
    where StaffID = @StaffID And Password = @Password  
          
END  

GO
/****** Object:  StoredProcedure [dbo].[stpGetTotalPaymentByPatientID]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018  
-- Description: Return total payment for a patient 
-- =============================================  
CREATE PROCEDURE [dbo].[stpGetTotalPaymentByPatientID] 
    -- Add the parameters for the stored procedure here  
    @PatientID varchar(36),
	@StartDate datetime,
	@EndDate datetime,
	@TotalPayment decimal(18, 0) output
      
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Select @TotalPayment = ISNULL(SUM(ISNULL(Amount, 0)), 0) From Payments
    where PatientID = @PatientID and EntryDate >= @StartDate and EntryDate <= @EndDate
	return
          
END  

GO
/****** Object:  StoredProcedure [dbo].[stpInsertPatient]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018 
-- Description: To create a new patient  
-- =============================================  
CREATE PROCEDURE [dbo].[stpInsertPatient]  
@PatientID varchar(36), 
@Firstname varchar(50),
@Lastname varchar(50), 
@Email varchar(50),
@PhoneNo varchar(15), 
@EntryDate datetime, 
@CreatedBy varchar(50),
@TotalPayment decimal(18,0)
  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Insert into Patients (PatientID, Firstname, Lastname, Email, PhoneNo, EntryDate, CreatedBy, TotalPayment)   
           Values (@PatientID, @Firstname, @Lastname, @Email, @PhoneNo, @EntryDate, @CreatedBy, @TotalPayment)  
  
END  

GO
/****** Object:  StoredProcedure [dbo].[stpInsertPayment]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018 
-- Description: To create a new payment  
-- =============================================  
CREATE PROCEDURE [dbo].[stpInsertPayment]  
@PaymentID varchar(36), 
@PatientID varchar(36),
@Description varchar(50), 
@EntryDate datetime, 
@Amount decimal(18,0), 
@CreatedBy varchar(50) 
  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  

    Insert into Payments (PaymentID, PatientID, Description, EntryDate, Amount, CreatedBy)   
           Values (@PaymentID, @PatientID, @Description, @EntryDate, @Amount, @CreatedBy)
  
END  

GO
/****** Object:  StoredProcedure [dbo].[stpInsertStaff]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018 
-- Description: To create a new staff  
-- =============================================  
CREATE PROCEDURE [dbo].[stpInsertStaff]  
@StaffID varchar(50), @Firstname varchar(50),
@Lastname varchar(50), @Password varchar(50),
@EntryDate datetime, @CreatedBy varchar(50),
@StaffNo varchar(50)
  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    Insert into Staff (StaffID, Firstname, Lastname, Password, EntryDate, CreatedBy, StaffNo)   
           Values (@StaffID, @Firstname, @Lastname, @Password, @EntryDate, @CreatedBy, @StaffNo)  
  
END  

GO
/****** Object:  StoredProcedure [dbo].[stpUpdateStaffPswdByStaffID]    Script Date: 05/01/2019 01:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:      Adeyemi Olaopa  
-- Create Date: 22-Dec-2018  
-- Description: Update a staff password by ID  
-- =============================================  
CREATE PROCEDURE [dbo].[stpUpdateStaffPswdByStaffID]  
@StaffID varchar(30),  @Password varchar(30)
  
AS  
BEGIN  
    -- SET NOCOUNT ON added to prevent extra result sets from  
    -- interfering with SELECT statements.  
    SET NOCOUNT ON;  
  
    UPDATE Staff  
    Set Password = @Password
    Where StaffID = @StaffID  
END  

GO
USE [master]
GO
ALTER DATABASE [stnicholas-payment-db] SET  READ_WRITE 
GO
