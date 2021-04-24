USE [master]
GO
/****** Object:  Database [TaxationDb]    Script Date: 2/29/2020 6:20:25 PM ******/
CREATE DATABASE [TaxationDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaxationDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TaxationDb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TaxationDb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TaxationDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TaxationDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
	EXEC [TaxationDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TaxationDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TaxationDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TaxationDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TaxationDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TaxationDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TaxationDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TaxationDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TaxationDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TaxationDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TaxationDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TaxationDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TaxationDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TaxationDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TaxationDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TaxationDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TaxationDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TaxationDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TaxationDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TaxationDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TaxationDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TaxationDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TaxationDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TaxationDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TaxationDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TaxationDb] SET  MULTI_USER 
GO
ALTER DATABASE [TaxationDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TaxationDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TaxationDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TaxationDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TaxationDb]
GO
/****** Object:  Table [dbo].[Basicinformations]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Basicinformations]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[AssessmentYear] [varchar](max) NULL,
	[ReturnSubmitted] [varchar](max) NULL,
	[NameOfAssessee] [varchar](max) NULL,
	[Gender] [varchar](max) NULL,
	[NewTIN] [varchar](max) NULL,
	[OldTIN] [varchar](max) NULL,
	[Circle] [varchar](max) NULL,
	[Zone] [varchar](max) NULL,
	[ResidentStatus] [varchar](max) NULL,
	[TickOnBoxes] [varchar](max) NULL,
	[DateOfBirth] [varchar](max) NULL,
	[YearFrom] [varchar](max) NULL,
	[YearTo] [varchar](max) NULL,
	[EmployerName] [varchar](max) NULL,
	[SpouseName] [varchar](max) NULL,
	[SpouseTIN] [varchar](max) NULL,
	[FatherName] [varchar](max) NULL,
	[MotherName] [varchar](max) NULL,
	[PresentAddress] [varchar](max) NULL,
	[PermanentAddress] [varchar](max) NULL,
	[ContactTelephone] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[NID] [varchar](max) NULL,
	[BIN] [varchar](max) NULL,
	[Salaries] [varchar](max) NULL,
	[InterestOnSecurities] [varchar](max) NULL,
	[IncomeFromHouseProperty] [varchar](max) NULL,
	[AgriculturalIncome] [varchar](max) NULL,
	[IncomeFromBusinessOrProfession] [varchar](max) NULL,
	[CapitalGains] [varchar](max) NULL,
	[IncomeFromOtherSources] [varchar](max) NULL,
	[ShareOfIncomeFromFirmOrAOP] [varchar](max) NULL,
	[IncomeOfMinor] [varchar](max) NULL,
	[ForeignIncome] [varchar](max) NULL,
	[TotalIncome] [varchar](max) NULL,
	[GrossTaxBeforeTaxRebate] [varchar](max) NULL,
	[TaxRebate] [varchar](max) NULL,
	[NetTaxAfterTaxRebate] [varchar](max) NULL,
	[MinimumTax] [varchar](max) NULL,
	[NetWealthSurcharge] [varchar](max) NULL,
	[InterestOrOrdinance] [varchar](max) NULL,
	[TotalAmountPayable] [varchar](max) NULL,
	[TaxDeducted] [varchar](max) NULL,
	[AdvanceTaxPaid] [varchar](max) NULL,
	[AdjustmentOfTaxRefund] [varchar](max) NULL,
	[AmountPaidWithReturn] [varchar](max) NULL,
	[TotalAmountPaidAndAdjusted] [varchar](max) NULL,
	[DeficitOrExcess] [varchar](max) NULL,
	[TaxExemptedIncome] [varchar](max) NULL,
	[IsParentOfPersonWithDisability] [varchar](max) NULL,
	[AreYouRequiredToSubmitStatementOfAssets] [varchar](max) NULL,
	[SchedulesAnnexed] [varchar](max) NULL,
	[StatementsAnnexed] [varchar](max) NULL,
	[OtherStatementsDocuments] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[Signature] [varchar](max) NULL,
	[DateOfSignature] [varchar](max) NULL,
	[PlaceOfSignatur] [varchar](max) NULL,
	[DateOfSubmition] [varchar](max) NULL,
	[TaxOfficeEntryNumber] [varchar](max) NULL,
	[AdditionalColumn] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Incomes]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Incomes]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SalaryAndAllowanceId] [bigint] NULL,
	[UserId] [bigint] NULL,
	[Incomee] [float] NULL,
	[TaxFreeIncome] [float] NULL,
	[TaxableIncome] [float] NULL,
	[Active] [bit] NULL,
	CONSTRAINT [PK_Incomes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invesments]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invesments]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[InvesmentName] [nvarchar](max) NULL,
	[Amount] [float] NULL,
	[Active] [bit] NULL,
	CONSTRAINT [PK_Invesments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ParticularsOfTaxCredits]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParticularsOfTaxCredits]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[AssessmentYear] [varchar](max) NULL,
	[TIN] [varchar](max) NULL,
	[LifeInsurance] [varchar](max) NULL,
	[ContributionToDeposit] [varchar](max) NULL,
	[InvestmentInApprovedSavings] [varchar](max) NULL,
	[InvestmentInApprovedDebenture] [varchar](max) NULL,
	[ContributionToProvidentFund] [varchar](max) NULL,
	[SelfContributionAndEmployer] [varchar](max) NULL,
	[ContributionToSuperAnnuationFund] [varchar](max) NULL,
	[ContributionToBenevolentFund] [varchar](max) NULL,
	[ContributionToZakatFund] [varchar](max) NULL,
	[OthersIfAny] [varchar](max) NULL,
	[TotalAllowableInvestment] [varchar](max) NULL,
	[EligibleAmountForRebate] [varchar](max) NULL,
	[TotalAllowableInvestmentContribution] [varchar](max) NULL,
	[TotalIncome14B] [varchar](max) NULL,
	[Crore14C] [varchar](max) NULL,
	[AmountOfTaxRebateCalculated] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[SignatureAndDatePhoto] [varchar](max) NULL,
	CONSTRAINT [PK_ParticularsOfTaxCredits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RebateCalculations]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RebateCalculations]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[ActualInvestment] [nvarchar](max) NULL,
	[Amount] [float] NULL,
	[Active] [bit] NULL,
	CONSTRAINT [PK_RebateCalculations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalaryAndAllowances]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryAndAllowances]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SalaryAndAllowanceName] [nvarchar](max) NULL,
	[Active] [bit] NULL,
	CONSTRAINT [PK_SalaryAndAllowances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatementOfAssets]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatementOfAssets]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[AssessmentYear] [varchar](max) NULL,
	[StatementAsOn] [varchar](max) NULL,
	[NameOfAssessee] [varchar](max) NULL,
	[TIN] [varchar](max) NULL,
	[BusinessCapital] [varchar](max) NULL,
	[BusinessCapital05A] [varchar](max) NULL,
	[DirectorShareholdingsInLimitedCompanies05B] [varchar](max) NULL,
	[NonAgricultural06A] [varchar](max) NULL,
	[AdvanceMadeForNonAgriculturalProperty06B] [varchar](max) NULL,
	[AgriculturalProperty07] [varchar](max) NULL,
	[FinancialAssetsValue08] [varchar](max) NULL,
	[ShareDebentures08A] [varchar](max) NULL,
	[SavingsCertificate08B] [varchar](max) NULL,
	[FixedDeposit08C] [varchar](max) NULL,
	[LoansGivenToOthers08D] [varchar](max) NULL,
	[OtherFinancialAssets08D] [varchar](max) NULL,
	[MotorCars09] [varchar](max) NULL,
	[GoldDiamond10] [varchar](max) NULL,
	[FurnitureEquipmentAndElectronicItems11] [varchar](max) NULL,
	[OtherAssetsOfSignificantValue12] [varchar](max) NULL,
	[CashAndFundOutsideBusiness] [varchar](max) NULL,
	[NotesAndCurrencies13A] [varchar](max) NULL,
	[BanksCardsAndOtherElectronicCash13B] [varchar](max) NULL,
	[ProvidentFundAndOtherFund13C] [varchar](max) NULL,
	[OtherDepositBalanceAndAdvance13D] [varchar](max) NULL,
	[GrossWealth14] [varchar](max) NULL,
	[LiabilitiesButsideBusines15] [varchar](max) NULL,
	[BorrowingsFromBanks15A] [varchar](max) NULL,
	[UnsecuredLoan15B] [varchar](max) NULL,
	[OtherLoansOrOverdrafts15C] [varchar](max) NULL,
	[NetWealth16] [varchar](max) NULL,
	[NetWealth17] [varchar](max) NULL,
	[ChangeIn18] [varchar](max) NULL,
	[OtherFundOutflow19] [varchar](max) NULL,
	[AnnualLiving19A] [varchar](max) NULL,
	[LossDeductionsExpenses19B] [varchar](max) NULL,
	[GiftDonation19C] [varchar](max) NULL,
	[TotalFundOutflow20] [varchar](max) NULL,
	[SourcesOfFund21] [varchar](max) NULL,
	[IncomeShown21A] [varchar](max) NULL,
	[TaxExempted21B] [varchar](max) NULL,
	[OtherReceipts21C] [varchar](max) NULL,
	[ShortageOfFund22] [varchar](max) NULL,
	[SecondPageName] [varchar](max) NULL,
	[SecondPagePhotoPath] [varchar](max) NULL,
	[ThirdPageName] [varchar](max) NULL,
	[ThirdPagePhtotPath] [varchar](max) NULL,
	[Active] [bit] NULL,
	CONSTRAINT [PK_StatementOfAssets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatementOfExpenses]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatementOfExpenses]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[AssessmentYear] [varchar](max) NULL,
	[StatementDate] [varchar](max) NULL,
	[NameOfAssessee] [varchar](max) NULL,
	[TIN] [varchar](max) NULL,
	[AgriculturalProperty] [varchar](max) NULL,
	[HousingExpense] [varchar](max) NULL,
	[AutoAndTransportationExpenses07A08B] [varchar](max) NULL,
	[DriverSalary07A] [varchar](max) NULL,
	[OtherTransportation] [varchar](max) NULL,
	[HouseholdAndUtilityExpenses08A08B08C08D] [varchar](max) NULL,
	[Electricity08A] [varchar](max) NULL,
	[GasWaterSewerAndGarbage08B] [varchar](max) NULL,
	[PhoneInternet08C] [varchar](max) NULL,
	[HomeSupport08D] [varchar](max) NULL,
	[ChildrenEducation] [varchar](max) NULL,
	[SpecialExpenses10A10B10C10D] [varchar](max) NULL,
	[FestivalParty10A] [varchar](max) NULL,
	[DomesticAndOverseasTour10B] [varchar](max) NULL,
	[Donation10C] [varchar](max) NULL,
	[OtherSpecialExpenses10D] [varchar](max) NULL,
	[AnyOtherExpenses] [varchar](max) NULL,
	[TotalExpenseRelating] [varchar](max) NULL,
	[PaymentOfTax13A13B] [varchar](max) NULL,
	[PaymentOfTax13A] [varchar](max) NULL,
	[PaymentOfTax13B] [varchar](max) NULL,
	[TotalAmountOfExpense] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[SignatureAndDatePhotoPath] [varchar](max) NULL,
	CONSTRAINT [PK_StatementOfExpenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInformations]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInformations]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[AssessmentYear] [varchar](50) NULL,
	[NameOfAssessee] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[NewTIN] [varchar](50) NULL,
	[OldTIN] [varchar](50) NULL,
	[Circle] [varchar](50) NULL,
	[Zone] [varchar](50) NULL,
	[TickOnBoxes] [varchar](350) NULL,
	[DateOfBirth] [varchar](50) NULL,
	[IncomeYearFrom] [varchar](50) NULL,
	[IncomeYearTo] [varchar](50) NULL,
	[EmployerName] [varchar](50) NULL,
	[SpouseName] [varchar](max) NULL,
	[SpouseTIN] [varchar](max) NULL,
	[FatherName] [varchar](max) NULL,
	[MotherName] [varchar](max) NULL,
	[PresentAddress] [varchar](max) NULL,
	[PermanentAddress] [varchar](max) NULL,
	[ContactTelephone] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[NID] [varchar](50) NULL,
	[BIN] [varchar](50) NULL,
	[ReturnSubmitted] [varchar](50) NULL,
	[ResidentStatus] [varchar](50) NULL,
	CONSTRAINT [PK_BasicInformationsPartOne] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2/29/2020 6:20:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users]
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[LastName] [varchar](150) NULL,
	[Email] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[ConfirmPassword] [varchar](max) NULL,
	[IsEmailConfirmed] [bit] NULL,
	[Active] [bit] NULL,
	[PhotoPath] [varchar](max) NULL,
	CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Basicinformations] ON

INSERT [dbo].[Basicinformations]
	([Id], [UserId], [AssessmentYear], [ReturnSubmitted], [NameOfAssessee], [Gender], [NewTIN], [OldTIN], [Circle], [Zone], [ResidentStatus], [TickOnBoxes], [DateOfBirth], [YearFrom], [YearTo], [EmployerName], [SpouseName], [SpouseTIN], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [ContactTelephone], [Email], [NID], [BIN], [Salaries], [InterestOnSecurities], [IncomeFromHouseProperty], [AgriculturalIncome], [IncomeFromBusinessOrProfession], [CapitalGains], [IncomeFromOtherSources], [ShareOfIncomeFromFirmOrAOP], [IncomeOfMinor], [ForeignIncome], [TotalIncome], [GrossTaxBeforeTaxRebate], [TaxRebate], [NetTaxAfterTaxRebate], [MinimumTax], [NetWealthSurcharge], [InterestOrOrdinance], [TotalAmountPayable], [TaxDeducted], [AdvanceTaxPaid], [AdjustmentOfTaxRefund], [AmountPaidWithReturn], [TotalAmountPaidAndAdjusted], [DeficitOrExcess], [TaxExemptedIncome], [IsParentOfPersonWithDisability], [AreYouRequiredToSubmitStatementOfAssets], [SchedulesAnnexed], [StatementsAnnexed], [OtherStatementsDocuments], [Name], [Signature], [DateOfSignature], [PlaceOfSignatur], [DateOfSubmition], [TaxOfficeEntryNumber], [AdditionalColumn])
VALUES
	(6, 5, N'2020-02-29', N'No', N'Jane', N'Male', N'1234567890', N'1234567890', N'Some Circle', N'zone', N'Yes', N'A gazetted war-wounded freedom fighter, ', N'2020-02-27', N'2019', N'2020', N'Max', N'Doe', N'1234567890', N'Jane Jane', N'Maxi Millian', N'2143  Randall Drive, Dc 96815, America', N'2143  Randall Drive, Dc 96815, America', N'343432432333', N'max.cse2019@gmail.com', N'1234567890', N'12232783287', N'4334', NULL, NULL, NULL, NULL, N'43434', NULL, NULL, NULL, NULL, NULL, N'43434', NULL, NULL, NULL, NULL, NULL, NULL, N'43434', NULL, NULL, NULL, NULL, NULL, N'4343', N'yes', NULL, NULL, NULL, NULL, NULL, N'~/Images/BasicInformationImages/ebff8c90-f990-43ce-859b-ea2c300a48bc_404_250px.png', NULL, N'~/Images/BasicInformationImages/409e4135-f5ae-4cba-b453-eaf92a2d52d4_404_250px.png', NULL, NULL, N'none')
SET IDENTITY_INSERT [dbo].[Basicinformations] OFF
SET IDENTITY_INSERT [dbo].[ParticularsOfTaxCredits] ON

INSERT [dbo].[ParticularsOfTaxCredits]
	([Id], [UserId], [AssessmentYear], [TIN], [LifeInsurance], [ContributionToDeposit], [InvestmentInApprovedSavings], [InvestmentInApprovedDebenture], [ContributionToProvidentFund], [SelfContributionAndEmployer], [ContributionToSuperAnnuationFund], [ContributionToBenevolentFund], [ContributionToZakatFund], [OthersIfAny], [TotalAllowableInvestment], [EligibleAmountForRebate], [TotalAllowableInvestmentContribution], [TotalIncome14B], [Crore14C], [AmountOfTaxRebateCalculated], [Name], [SignatureAndDatePhoto])
VALUES
	(1, 1, N'2020-02-27', N'123213', N'LifeInsurance', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'OthersIfAny', NULL, NULL, NULL, NULL, NULL, NULL, N'Wahida', N'~/Images/BasicInformationImages/3b7d79ec-6bac-4e45-9118-99d0ca28c18c_img.jpg')
INSERT [dbo].[ParticularsOfTaxCredits]
	([Id], [UserId], [AssessmentYear], [TIN], [LifeInsurance], [ContributionToDeposit], [InvestmentInApprovedSavings], [InvestmentInApprovedDebenture], [ContributionToProvidentFund], [SelfContributionAndEmployer], [ContributionToSuperAnnuationFund], [ContributionToBenevolentFund], [ContributionToZakatFund], [OthersIfAny], [TotalAllowableInvestment], [EligibleAmountForRebate], [TotalAllowableInvestmentContribution], [TotalIncome14B], [Crore14C], [AmountOfTaxRebateCalculated], [Name], [SignatureAndDatePhoto])
VALUES
	(2, 5, N'2020-02-29', N'1234567890', N'53453', N'4535', N'9485048609568', NULL, NULL, NULL, N'435435', NULL, NULL, N'543543', NULL, N'53555555', N'5345', N'5435', NULL, N'5345435', N'Wahida', N'~/Images/BasicInformationImages/bb9d4c6f-d98b-4371-9b0d-16fbf4219a94_404_250px.png')
SET IDENTITY_INSERT [dbo].[ParticularsOfTaxCredits] OFF
SET IDENTITY_INSERT [dbo].[SalaryAndAllowances] ON

INSERT [dbo].[SalaryAndAllowances]
	([Id], [SalaryAndAllowanceName], [Active])
VALUES
	(1, N'Income And Allowences', 1)
INSERT [dbo].[SalaryAndAllowances]
	([Id], [SalaryAndAllowanceName], [Active])
VALUES
	(2, N'Basic Salary', 1)
INSERT [dbo].[SalaryAndAllowances]
	([Id], [SalaryAndAllowanceName], [Active])
VALUES
	(3, N'House Rent', 1)
SET IDENTITY_INSERT [dbo].[SalaryAndAllowances] OFF
SET IDENTITY_INSERT [dbo].[StatementOfAssets] ON

INSERT [dbo].[StatementOfAssets]
	([Id], [UserId], [AssessmentYear], [StatementAsOn], [NameOfAssessee], [TIN], [BusinessCapital], [BusinessCapital05A], [DirectorShareholdingsInLimitedCompanies05B], [NonAgricultural06A], [AdvanceMadeForNonAgriculturalProperty06B], [AgriculturalProperty07], [FinancialAssetsValue08], [ShareDebentures08A], [SavingsCertificate08B], [FixedDeposit08C], [LoansGivenToOthers08D], [OtherFinancialAssets08D], [MotorCars09], [GoldDiamond10], [FurnitureEquipmentAndElectronicItems11], [OtherAssetsOfSignificantValue12], [CashAndFundOutsideBusiness], [NotesAndCurrencies13A], [BanksCardsAndOtherElectronicCash13B], [ProvidentFundAndOtherFund13C], [OtherDepositBalanceAndAdvance13D], [GrossWealth14], [LiabilitiesButsideBusines15], [BorrowingsFromBanks15A], [UnsecuredLoan15B], [OtherLoansOrOverdrafts15C], [NetWealth16], [NetWealth17], [ChangeIn18], [OtherFundOutflow19], [AnnualLiving19A], [LossDeductionsExpenses19B], [GiftDonation19C], [TotalFundOutflow20], [SourcesOfFund21], [IncomeShown21A], [TaxExempted21B], [OtherReceipts21C], [ShortageOfFund22], [SecondPageName], [SecondPagePhotoPath], [ThirdPageName], [ThirdPagePhtotPath], [Active])
VALUES
	(3, 1, N'2020-02-27', NULL, N'Jane', N'123213', N'543', N'34343', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'3443', NULL, NULL, N'23432', N'423432', NULL, NULL, NULL, N'435', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'3243243232432', NULL, N'43543', NULL, N'trete', N'~/Images/StatementOfAssetImages/4555bb13-e6db-4d46-ba23-3fc40c2497f1_img1.jpg', N'rwerwerwerewrwerwe', N'~/Images/StatementOfAssetImages/5d489e77-416b-4dd8-bd88-313bb3b5b063_img1.jpg', 0)
INSERT [dbo].[StatementOfAssets]
	([Id], [UserId], [AssessmentYear], [StatementAsOn], [NameOfAssessee], [TIN], [BusinessCapital], [BusinessCapital05A], [DirectorShareholdingsInLimitedCompanies05B], [NonAgricultural06A], [AdvanceMadeForNonAgriculturalProperty06B], [AgriculturalProperty07], [FinancialAssetsValue08], [ShareDebentures08A], [SavingsCertificate08B], [FixedDeposit08C], [LoansGivenToOthers08D], [OtherFinancialAssets08D], [MotorCars09], [GoldDiamond10], [FurnitureEquipmentAndElectronicItems11], [OtherAssetsOfSignificantValue12], [CashAndFundOutsideBusiness], [NotesAndCurrencies13A], [BanksCardsAndOtherElectronicCash13B], [ProvidentFundAndOtherFund13C], [OtherDepositBalanceAndAdvance13D], [GrossWealth14], [LiabilitiesButsideBusines15], [BorrowingsFromBanks15A], [UnsecuredLoan15B], [OtherLoansOrOverdrafts15C], [NetWealth16], [NetWealth17], [ChangeIn18], [OtherFundOutflow19], [AnnualLiving19A], [LossDeductionsExpenses19B], [GiftDonation19C], [TotalFundOutflow20], [SourcesOfFund21], [IncomeShown21A], [TaxExempted21B], [OtherReceipts21C], [ShortageOfFund22], [SecondPageName], [SecondPagePhotoPath], [ThirdPageName], [ThirdPagePhtotPath], [Active])
VALUES
	(4, 5, N'2020-02-29', NULL, N'Maxi Millian', N'1234567890', NULL, NULL, NULL, NULL, NULL, N'432342342342342342423', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'43242342', N'34234234', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'432432423412321312321', NULL, NULL, NULL, N'~/Images/StatementOfAssetImages/4b71ed76-8fb6-4259-af25-10d0b7b0f1db_404_250px.png', NULL, N'~/Images/StatementOfAssetImages/7410536f-4c63-41ad-bb60-0a7f100f6d5a_404_250px.png', 0)
SET IDENTITY_INSERT [dbo].[StatementOfAssets] OFF
SET IDENTITY_INSERT [dbo].[StatementOfExpenses] ON

INSERT [dbo].[StatementOfExpenses]
	([Id], [UserId], [AssessmentYear], [StatementDate], [NameOfAssessee], [TIN], [AgriculturalProperty], [HousingExpense], [AutoAndTransportationExpenses07A08B], [DriverSalary07A], [OtherTransportation], [HouseholdAndUtilityExpenses08A08B08C08D], [Electricity08A], [GasWaterSewerAndGarbage08B], [PhoneInternet08C], [HomeSupport08D], [ChildrenEducation], [SpecialExpenses10A10B10C10D], [FestivalParty10A], [DomesticAndOverseasTour10B], [Donation10C], [OtherSpecialExpenses10D], [AnyOtherExpenses], [TotalExpenseRelating], [PaymentOfTax13A13B], [PaymentOfTax13A], [PaymentOfTax13B], [TotalAmountOfExpense], [Name], [SignatureAndDatePhotoPath])
VALUES
	(2, 1, N'2020-02-27', N'2020-02-11', N'Jane', N'123213', N'Test Comment', N'HGello', N'Hello', NULL, NULL, N'Hello', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Hello', NULL, N'Other special expenses', NULL, NULL, NULL, NULL, NULL, N'Hello', N'Wahida', N'~/Images/StatementOfExpensesImages/9ef24ae5-a020-4b42-97bb-c299c80d6349_img.jpg')
INSERT [dbo].[StatementOfExpenses]
	([Id], [UserId], [AssessmentYear], [StatementDate], [NameOfAssessee], [TIN], [AgriculturalProperty], [HousingExpense], [AutoAndTransportationExpenses07A08B], [DriverSalary07A], [OtherTransportation], [HouseholdAndUtilityExpenses08A08B08C08D], [Electricity08A], [GasWaterSewerAndGarbage08B], [PhoneInternet08C], [HomeSupport08D], [ChildrenEducation], [SpecialExpenses10A10B10C10D], [FestivalParty10A], [DomesticAndOverseasTour10B], [Donation10C], [OtherSpecialExpenses10D], [AnyOtherExpenses], [TotalExpenseRelating], [PaymentOfTax13A13B], [PaymentOfTax13A], [PaymentOfTax13B], [TotalAmountOfExpense], [Name], [SignatureAndDatePhotoPath])
VALUES
	(3, 5, N'2020-02-29', N'2020-02-25', N'Maxi Millian', N'1234567890', N'Test Comment', N'HGello', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'~/Images/StatementOfExpensesImages/cc3d49cc-4792-4c60-9a8a-47da8f40a722_Screenshot_2020-02-21 Firebase.png')
SET IDENTITY_INSERT [dbo].[StatementOfExpenses] OFF
SET IDENTITY_INSERT [dbo].[UserInformations] ON

INSERT [dbo].[UserInformations]
	([Id], [UserId], [AssessmentYear], [NameOfAssessee], [Gender], [NewTIN], [OldTIN], [Circle], [Zone], [TickOnBoxes], [DateOfBirth], [IncomeYearFrom], [IncomeYearTo], [EmployerName], [SpouseName], [SpouseTIN], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [ContactTelephone], [Email], [NID], [BIN], [ReturnSubmitted], [ResidentStatus])
VALUES
	(23, 5, N'2020-02-29', N'Maxi Millian', N'Male', N'1234567890', N'1234567890', N'Some Circle', N'Florida', NULL, N'2012-12-29', N'2019', N'2020', N'Max', N'Doe', N'1234567890', N'Max Horran ', N'Nicola', N'2143  Randall Drive, Dc 96815, America', N'2143  Randall Drive, Dc 96815, America', N'343432432333', N'max.cse2019@gmail.com', N'1234567890', N'12232783287', N'Yes', N'Yes')
INSERT [dbo].[UserInformations]
	([Id], [UserId], [AssessmentYear], [NameOfAssessee], [Gender], [NewTIN], [OldTIN], [Circle], [Zone], [TickOnBoxes], [DateOfBirth], [IncomeYearFrom], [IncomeYearTo], [EmployerName], [SpouseName], [SpouseTIN], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [ContactTelephone], [Email], [NID], [BIN], [ReturnSubmitted], [ResidentStatus])
VALUES
	(24, 0, N'2020-02-29', N'Jane', N'Male', N'1234567890', N'1234567890', N'Some Circle', N'zone', N'A gazetted war-wounded freedom fighter, ', N'2020-02-27', N'2019', N'2020', N'Max', N'Doe', N'1234567890', N'Jane Jane', N'Maxi Millian', N'2143  Randall Drive, Dc 96815, America', N'2143  Randall Drive, Dc 96815, America', N'343432432333', N'max.cse2019@gmail.com', N'1234567890', N'12232783287', NULL, N'Yes')
SET IDENTITY_INSERT [dbo].[UserInformations] OFF
SET IDENTITY_INSERT [dbo].[Users] ON

INSERT [dbo].[Users]
	([Id], [FirstName], [LastName], [Email], [Password], [ConfirmPassword], [IsEmailConfirmed], [Active], [PhotoPath])
VALUES
	(5, N'Max', N'Millian', N'max.cse2019@gmail.com', N'123456', N'123456', 0, 0, N'~/Images/UserImages/cc151e4e-c3fc-4ca0-ae10-99dd9afa3a2b_admin.jpg')
INSERT [dbo].[Users]
	([Id], [FirstName], [LastName], [Email], [Password], [ConfirmPassword], [IsEmailConfirmed], [Active], [PhotoPath])
VALUES
	(6, N'test', N'test', N'test1@gmail.com', N'123456', N'123456', 0, 0, N'~/Images/UserImages/1ba53792-a4c4-4028-a7dd-7f6156a5eea0_404_250px.png')
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [TaxationDb] SET  READ_WRITE 
GO
