USE [master]
GO
/****** Object:  Database [TaxationDb]    Script Date: 3/3/2021 3:11:27 PM ******/
CREATE DATABASE [TaxationDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaxationDb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TaxationDb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
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
/****** Object:  Table [dbo].[Admins]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admins](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](240) NULL,
	[Email] [varchar](240) NULL,
	[Password] [varchar](max) NULL,
	[ConfirmPassword] [varchar](max) NULL,
	[AdminType] [varchar](10) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Basicinformations]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Basicinformations](
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
	[AdditionalColumn] [varchar](max) NULL,
	[EmployeementStatus] [varchar](15) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DpsInfoes]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DpsInfoes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BankName] [varchar](250) NOT NULL,
	[Amount] [varchar](max) NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_DpsInfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FinalCalculations]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FinalCalculations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[PayableTax] [varchar](max) NULL,
	[RebateOnInvestment] [varchar](max) NULL,
	[TaxPayable] [varchar](max) NULL,
	[Surcharge] [varchar](max) NULL,
	[DeductedSource] [varchar](max) NULL,
	[DeductedSourceBank] [varchar](max) NULL,
	[NetPayableTax] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Incomes]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Incomes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[TotalIncome] [varchar](500) NULL,
	[TotalTaxFreeIncome] [varchar](500) NULL,
	[TotalTaxableIncome] [varchar](500) NULL,
	[IsActive] [varchar](500) NULL,
 CONSTRAINT [PK_Incomes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Insurances]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Insurances](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[Amount] [bigint] NULL,
	[CompanyName] [varchar](max) NULL,
	[Year] [varchar](max) NULL,
 CONSTRAINT [PK_Insurances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Invesments]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invesments](
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
/****** Object:  Table [dbo].[ParticularsOfIncomeAmounts]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParticularsOfIncomeAmounts](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[BasicPay] [varchar](max) NULL,
	[SpecialPay] [varchar](max) NULL,
	[ArrearPay] [varchar](max) NULL,
	[DearnessAllowance] [varchar](max) NULL,
	[HouseRentAllowance] [varchar](max) NULL,
	[MedicalAllowance] [varchar](max) NULL,
	[ConveyanceAllowance] [varchar](max) NULL,
	[FestivalAllowance] [varchar](max) NULL,
	[AllowanceStaff] [varchar](max) NULL,
	[LeaveAllowance] [varchar](max) NULL,
	[HonorariumAmount] [varchar](max) NULL,
	[OvertimeAllowance] [varchar](max) NULL,
	[BonusAmount] [varchar](max) NULL,
	[OtherAllowances] [varchar](max) NULL,
	[EmployerContribution] [varchar](max) NULL,
	[InterestAccrued] [varchar](max) NULL,
	[DeemedIncomeTransport] [varchar](max) NULL,
	[DeemedIncomeFurnished] [varchar](max) NULL,
	[OtherIfAny] [varchar](max) NULL,
	[AmountTotal] [varchar](max) NULL,
 CONSTRAINT [PK_TexCreditAmounts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ParticularsOfIncomeFromSalaries]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParticularsOfIncomeFromSalaries](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[AssessmentYear] [varchar](max) NULL,
	[TIN] [varchar](max) NULL,
	[BasicPayTaxable] [varchar](max) NULL,
	[SpecialPayTaxable] [varchar](max) NULL,
	[ArrearPayTaxable] [varchar](max) NULL,
	[DearnessAllowanceTaxable] [varchar](max) NULL,
	[HouseRentAllowanceTaxable] [varchar](max) NULL,
	[MedicalAllowanceTaxable] [varchar](max) NULL,
	[ConveyanceAllowanceTaxable] [varchar](max) NULL,
	[FestivalAllowanceTaxable] [varchar](max) NULL,
	[AllowanceStaffTaxable] [varchar](max) NULL,
	[LeaveAllowanceTaxable] [varchar](max) NULL,
	[HonorariumTaxable] [varchar](max) NULL,
	[OvertimeAllowanceTaxable] [varchar](max) NULL,
	[BonusTaxable] [varchar](max) NULL,
	[OtherAllowancesTaxable] [varchar](max) NULL,
	[EmployerContributionTaxable] [varchar](max) NULL,
	[InterestAccruedTaxable] [varchar](max) NULL,
	[DeemedIncomeTransportTaxable] [varchar](max) NULL,
	[DeemedIncomeFurnishedTaxable] [varchar](max) NULL,
	[OtherIfAny] [varchar](max) NULL,
	[Total] [varchar](max) NULL,
	[PhotoPath] [varchar](max) NULL,
	[Name] [varchar](max) NULL,
	[EmployeementStatus] [varchar](15) NOT NULL,
	[TotalTaxExempted] [varchar](max) NULL,
	[GrossTaxBeforeTaxRebate] [varchar](max) NULL,
	[GrossTaxBeforeTaxRebateMaxPercentage] [varchar](max) NULL,
	[TotalSurcharge] [varchar](max) NULL,
	[SurchargePercentage] [varchar](max) NULL,
 CONSTRAINT [PK_ParticularsOfIncomeFromSalaries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ParticularsOfTaxCredits]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ParticularsOfTaxCredits](
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
	[EmployeementStatus] [varchar](15) NOT NULL,
 CONSTRAINT [PK_ParticularsOfTaxCredits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RebateCalculations]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RebateCalculations](
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
/****** Object:  Table [dbo].[SalaryAndAllowances]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaryAndAllowances](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SalaryAndAllowanceName] [nvarchar](max) NULL,
	[Active] [bit] NULL,
 CONSTRAINT [PK_SalaryAndAllowances] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[StatementOfAssets]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatementOfAssets](
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
	[EmployeementStatus] [varchar](15) NOT NULL,
	[BusinessCapital05B] [varchar](max) NULL,
	[TotalOf06A06B] [varchar](max) NULL,
	[IsPrevYearCalculated] [bit] NULL,
 CONSTRAINT [PK_StatementOfAssets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StatementOfExpenses]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StatementOfExpenses](
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
	[EmployeementStatus] [varchar](15) NOT NULL,
	[Total] [varchar](max) NULL,
 CONSTRAINT [PK_StatementOfExpenses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Surcharges]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Surcharges](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[SurchargeValue] [varchar](max) NULL,
	[SurchargePercentage] [varchar](max) NULL,
 CONSTRAINT [PK_Surcharges] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxableIncomeTaxes]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxableIncomeTaxes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[TaxableIncome] [varchar](max) NULL,
	[TaxRate] [varchar](max) NULL,
	[NetTax] [varchar](max) NULL,
	[UserId] [bigint] NULL,
 CONSTRAINT [PK_TaxableIncomeTax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxesBasedOnIncome]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxesBasedOnIncome](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TaxRate] [varchar](max) NULL,
	[NetTax] [varchar](max) NULL,
 CONSTRAINT [PK_TaxesBasedOnIncome] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TaxExempteds]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TaxExempteds](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NULL,
	[BasicPayTaxExempted] [varchar](max) NULL,
	[SpecialPayTaxExempted] [varchar](max) NULL,
	[ArrearPayTaxExempted] [varchar](max) NULL,
	[DearnessAllowanceTaxExempted] [varchar](max) NULL,
	[HouseRentAllowanceTaxExempted] [varchar](max) NULL,
	[MedicalAllowanceTaxExempted] [varchar](max) NULL,
	[ConveyanceAllowanceTaxExempted] [varchar](max) NULL,
	[FestivalAllowanceTaxExempted] [varchar](max) NULL,
	[AllowanceStaffTaxExempted] [varchar](max) NULL,
	[LeaveAllowanceTaxExempted] [varchar](max) NULL,
	[HonorariumTaxExempted] [varchar](max) NULL,
	[OvertimeAllowanceExempted] [varchar](max) NULL,
	[BonusExempted] [varchar](max) NULL,
	[OtherAllowancesExempted] [varchar](max) NULL,
	[EmployerContributionExempted] [varchar](max) NULL,
	[InterestAccruedExempted] [varchar](max) NULL,
	[DeemedIncomeTransportExempted] [varchar](max) NULL,
	[DeemedIncomeFurnishedExempted] [varchar](max) NULL,
	[OtherIfAnyExempted] [varchar](max) NULL,
	[TotalTaxExempted] [varchar](max) NULL,
 CONSTRAINT [PK_TaxExempteds] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TotalInfoes]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TotalInfoes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[Assets] [varchar](max) NULL,
	[Expenses] [varchar](max) NULL,
	[Slaries] [varchar](max) NULL,
	[TaxCredit] [varchar](max) NULL,
	[Investment] [varchar](max) NULL,
	[Rebate] [varchar](max) NULL,
	[Others] [varchar](max) NULL,
	[Income] [varchar](max) NULL,
 CONSTRAINT [PK_TotalInfoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInformations]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInformations](
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
	[EmployeementStatus] [varchar](15) NOT NULL,
	[VehiclesByOffice] [varchar](max) NULL,
	[HouseRentByOffice] [varchar](max) NULL,
	[Signature] [varchar](max) NULL,
 CONSTRAINT [PK_BasicInformationsPartOne] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Users]    Script Date: 3/3/2021 3:11:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](150) NULL,
	[LastName] [varchar](150) NULL,
	[Email] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[ConfirmPassword] [varchar](max) NULL,
	[IsEmailConfirmed] [bit] NULL,
	[Active] [bit] NULL,
	[PhotoPath] [varchar](max) NULL,
	[EmploymentStatus] [varchar](20) NULL,
	[Gender] [varchar](50) NULL,
	[IsAutistc] [bit] NULL,
	[RecoveryCode] [varchar](max) NULL,
	[Bio] [varchar](max) NULL,
	[WhoYouAre] [varchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Basicinformations] ON 

INSERT [dbo].[Basicinformations] ([Id], [UserId], [AssessmentYear], [ReturnSubmitted], [NameOfAssessee], [Gender], [NewTIN], [OldTIN], [Circle], [Zone], [ResidentStatus], [TickOnBoxes], [DateOfBirth], [YearFrom], [YearTo], [EmployerName], [SpouseName], [SpouseTIN], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [ContactTelephone], [Email], [NID], [BIN], [Salaries], [InterestOnSecurities], [IncomeFromHouseProperty], [AgriculturalIncome], [IncomeFromBusinessOrProfession], [CapitalGains], [IncomeFromOtherSources], [ShareOfIncomeFromFirmOrAOP], [IncomeOfMinor], [ForeignIncome], [TotalIncome], [GrossTaxBeforeTaxRebate], [TaxRebate], [NetTaxAfterTaxRebate], [MinimumTax], [NetWealthSurcharge], [InterestOrOrdinance], [TotalAmountPayable], [TaxDeducted], [AdvanceTaxPaid], [AdjustmentOfTaxRefund], [AmountPaidWithReturn], [TotalAmountPaidAndAdjusted], [DeficitOrExcess], [TaxExemptedIncome], [IsParentOfPersonWithDisability], [AreYouRequiredToSubmitStatementOfAssets], [SchedulesAnnexed], [StatementsAnnexed], [OtherStatementsDocuments], [Name], [Signature], [DateOfSignature], [PlaceOfSignatur], [DateOfSubmition], [TaxOfficeEntryNumber], [AdditionalColumn], [EmployeementStatus]) VALUES (10020, 10058, N'2021-03-03', N'No', N'Preash', N'Female', N'102030405060', N'1020304050', N'23', N'23', N'Yes', NULL, N'1994-05-28', N'2020', N'2021', N'Premier University', NULL, NULL, N'Goutam Roy', N'Shopna Roy', N'141, Wasa, Chittagong', N'141, Wasa, Chittagong', N'01871532836', N'towhid.cse2015to@gmail.com', N'1996324343232', NULL, N'4', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', NULL, N'1', NULL, N'5000', N'0', NULL, N'0', NULL, NULL, NULL, N'0', N'0', N'0', N'0', NULL, NULL, NULL, NULL, NULL, N'Preash', N'NOIMAGE_PATH', N'2021-03-03', N'Chattagram', N'2021-03-03', NULL, N'none', N'pvt')
SET IDENTITY_INSERT [dbo].[Basicinformations] OFF
SET IDENTITY_INSERT [dbo].[DpsInfoes] ON 

INSERT [dbo].[DpsInfoes] ([Id], [BankName], [Amount], [UserId]) VALUES (10118, N'Bank 1', N'36000', 10057)
INSERT [dbo].[DpsInfoes] ([Id], [BankName], [Amount], [UserId]) VALUES (10119, N'Bank 2', N'60000', 10057)
INSERT [dbo].[DpsInfoes] ([Id], [BankName], [Amount], [UserId]) VALUES (10120, N'Bank 3', N'60000', 10057)
INSERT [dbo].[DpsInfoes] ([Id], [BankName], [Amount], [UserId]) VALUES (10121, N'Bank 1', N'123', 10058)
SET IDENTITY_INSERT [dbo].[DpsInfoes] OFF
SET IDENTITY_INSERT [dbo].[Insurances] ON 

INSERT [dbo].[Insurances] ([Id], [UserId], [Amount], [CompanyName], [Year]) VALUES (10034, 10057, 133915, N'life Ins', N'2021')
SET IDENTITY_INSERT [dbo].[Insurances] OFF
SET IDENTITY_INSERT [dbo].[ParticularsOfIncomeAmounts] ON 

INSERT [dbo].[ParticularsOfIncomeAmounts] ([Id], [UserId], [BasicPay], [SpecialPay], [ArrearPay], [DearnessAllowance], [HouseRentAllowance], [MedicalAllowance], [ConveyanceAllowance], [FestivalAllowance], [AllowanceStaff], [LeaveAllowance], [HonorariumAmount], [OvertimeAllowance], [BonusAmount], [OtherAllowances], [EmployerContribution], [InterestAccrued], [DeemedIncomeTransport], [DeemedIncomeFurnished], [OtherIfAny], [AmountTotal]) VALUES (14, 10057, N'493320', NULL, NULL, NULL, N'197328', N'18000', NULL, N'8222', NULL, NULL, NULL, NULL, N'82220', NULL, N'49332', NULL, NULL, NULL, N'197328', NULL)
INSERT [dbo].[ParticularsOfIncomeAmounts] ([Id], [UserId], [BasicPay], [SpecialPay], [ArrearPay], [DearnessAllowance], [HouseRentAllowance], [MedicalAllowance], [ConveyanceAllowance], [FestivalAllowance], [AllowanceStaff], [LeaveAllowance], [HonorariumAmount], [OvertimeAllowance], [BonusAmount], [OtherAllowances], [EmployerContribution], [InterestAccrued], [DeemedIncomeTransport], [DeemedIncomeFurnished], [OtherIfAny], [AmountTotal]) VALUES (15, 10058, N'4', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', N'4', N'4', NULL, N'4', NULL, N'20')
SET IDENTITY_INSERT [dbo].[ParticularsOfIncomeAmounts] OFF
SET IDENTITY_INSERT [dbo].[ParticularsOfIncomeFromSalaries] ON 

INSERT [dbo].[ParticularsOfIncomeFromSalaries] ([Id], [UserId], [AssessmentYear], [TIN], [BasicPayTaxable], [SpecialPayTaxable], [ArrearPayTaxable], [DearnessAllowanceTaxable], [HouseRentAllowanceTaxable], [MedicalAllowanceTaxable], [ConveyanceAllowanceTaxable], [FestivalAllowanceTaxable], [AllowanceStaffTaxable], [LeaveAllowanceTaxable], [HonorariumTaxable], [OvertimeAllowanceTaxable], [BonusTaxable], [OtherAllowancesTaxable], [EmployerContributionTaxable], [InterestAccruedTaxable], [DeemedIncomeTransportTaxable], [DeemedIncomeFurnishedTaxable], [OtherIfAny], [Total], [PhotoPath], [Name], [EmployeementStatus], [TotalTaxExempted], [GrossTaxBeforeTaxRebate], [GrossTaxBeforeTaxRebateMaxPercentage], [TotalSurcharge], [SurchargePercentage]) VALUES (32, 10057, N'01-06-2021', N'102030405060', N'493320', NULL, NULL, NULL, N'0', N'0', NULL, N'8222', NULL, NULL, NULL, NULL, N'82220', NULL, N'49332', NULL, NULL, N'0', N'197328', N'830422', N'~/Images/IncomeFromSlariesImages/d9de7b68-61a1-4bbb-be9a-ba1ae1e5adfd_img_avatar3.png', N'Preash', N'pvt', N'215328', N'67063', N'15', NULL, NULL)
INSERT [dbo].[ParticularsOfIncomeFromSalaries] ([Id], [UserId], [AssessmentYear], [TIN], [BasicPayTaxable], [SpecialPayTaxable], [ArrearPayTaxable], [DearnessAllowanceTaxable], [HouseRentAllowanceTaxable], [MedicalAllowanceTaxable], [ConveyanceAllowanceTaxable], [FestivalAllowanceTaxable], [AllowanceStaffTaxable], [LeaveAllowanceTaxable], [HonorariumTaxable], [OvertimeAllowanceTaxable], [BonusTaxable], [OtherAllowancesTaxable], [EmployerContributionTaxable], [InterestAccruedTaxable], [DeemedIncomeTransportTaxable], [DeemedIncomeFurnishedTaxable], [OtherIfAny], [Total], [PhotoPath], [Name], [EmployeementStatus], [TotalTaxExempted], [GrossTaxBeforeTaxRebate], [GrossTaxBeforeTaxRebateMaxPercentage], [TotalSurcharge], [SurchargePercentage]) VALUES (33, 10058, N'2021-03-03', N'102030405060', N'4', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'4', N'4', N'3', NULL, N'0', NULL, N'15', NULL, N'Preash', N'pvt', N'1', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[ParticularsOfIncomeFromSalaries] OFF
SET IDENTITY_INSERT [dbo].[ParticularsOfTaxCredits] ON 

INSERT [dbo].[ParticularsOfTaxCredits] ([Id], [UserId], [AssessmentYear], [TIN], [LifeInsurance], [ContributionToDeposit], [InvestmentInApprovedSavings], [InvestmentInApprovedDebenture], [ContributionToProvidentFund], [SelfContributionAndEmployer], [ContributionToSuperAnnuationFund], [ContributionToBenevolentFund], [ContributionToZakatFund], [OthersIfAny], [TotalAllowableInvestment], [EligibleAmountForRebate], [TotalAllowableInvestmentContribution], [TotalIncome14B], [Crore14C], [AmountOfTaxRebateCalculated], [Name], [SignatureAndDatePhoto], [EmployeementStatus]) VALUES (10017, 10057, N'01-06-2021', N'102030405060', N'133915', N'60000', NULL, NULL, NULL, N'98664', NULL, NULL, NULL, NULL, N'292579', N'207606', N'292579', N'207606', N'150000000', N'31141', N'Preash', N'~/Images/BasicInformationImages/ce73ec09-b021-4abc-8b3e-d12ff8da8c94_img_avatar3.png', N'pvt')
INSERT [dbo].[ParticularsOfTaxCredits] ([Id], [UserId], [AssessmentYear], [TIN], [LifeInsurance], [ContributionToDeposit], [InvestmentInApprovedSavings], [InvestmentInApprovedDebenture], [ContributionToProvidentFund], [SelfContributionAndEmployer], [ContributionToSuperAnnuationFund], [ContributionToBenevolentFund], [ContributionToZakatFund], [OthersIfAny], [TotalAllowableInvestment], [EligibleAmountForRebate], [TotalAllowableInvestmentContribution], [TotalIncome14B], [Crore14C], [AmountOfTaxRebateCalculated], [Name], [SignatureAndDatePhoto], [EmployeementStatus]) VALUES (10018, 10058, N'01-06-2021', N'102030405060', N'133915', N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'133915', NULL, N'133915', N'1', N'150000000', N'1', N'Preash', N'NOIMAGE_PATH', N'pvt')
SET IDENTITY_INSERT [dbo].[ParticularsOfTaxCredits] OFF
SET IDENTITY_INSERT [dbo].[StatementOfAssets] ON 

INSERT [dbo].[StatementOfAssets] ([Id], [UserId], [AssessmentYear], [StatementAsOn], [NameOfAssessee], [TIN], [BusinessCapital], [BusinessCapital05A], [DirectorShareholdingsInLimitedCompanies05B], [NonAgricultural06A], [AdvanceMadeForNonAgriculturalProperty06B], [AgriculturalProperty07], [FinancialAssetsValue08], [ShareDebentures08A], [SavingsCertificate08B], [FixedDeposit08C], [LoansGivenToOthers08D], [OtherFinancialAssets08D], [MotorCars09], [GoldDiamond10], [FurnitureEquipmentAndElectronicItems11], [OtherAssetsOfSignificantValue12], [CashAndFundOutsideBusiness], [NotesAndCurrencies13A], [BanksCardsAndOtherElectronicCash13B], [ProvidentFundAndOtherFund13C], [OtherDepositBalanceAndAdvance13D], [GrossWealth14], [LiabilitiesButsideBusines15], [BorrowingsFromBanks15A], [UnsecuredLoan15B], [OtherLoansOrOverdrafts15C], [NetWealth16], [NetWealth17], [ChangeIn18], [OtherFundOutflow19], [AnnualLiving19A], [LossDeductionsExpenses19B], [GiftDonation19C], [TotalFundOutflow20], [SourcesOfFund21], [IncomeShown21A], [TaxExempted21B], [OtherReceipts21C], [ShortageOfFund22], [SecondPageName], [SecondPagePhotoPath], [ThirdPageName], [ThirdPagePhtotPath], [Active], [EmployeementStatus], [BusinessCapital05B], [TotalOf06A06B], [IsPrevYearCalculated]) VALUES (50043, 10058, N'01-06-2021', N'2021-03-02', N'Preash', N'102030405060', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, N'0', NULL, NULL, N'0', N'0', NULL, NULL, NULL, N'4', N'4', N'0', NULL, N'4', NULL, N'NOIMAGE_PATH', NULL, NULL, 0, N'pvt', NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[StatementOfAssets] OFF
SET IDENTITY_INSERT [dbo].[StatementOfExpenses] ON 

INSERT [dbo].[StatementOfExpenses] ([Id], [UserId], [AssessmentYear], [StatementDate], [NameOfAssessee], [TIN], [AgriculturalProperty], [HousingExpense], [AutoAndTransportationExpenses07A08B], [DriverSalary07A], [OtherTransportation], [HouseholdAndUtilityExpenses08A08B08C08D], [Electricity08A], [GasWaterSewerAndGarbage08B], [PhoneInternet08C], [HomeSupport08D], [ChildrenEducation], [SpecialExpenses10A10B10C10D], [FestivalParty10A], [DomesticAndOverseasTour10B], [Donation10C], [OtherSpecialExpenses10D], [AnyOtherExpenses], [TotalExpenseRelating], [PaymentOfTax13A13B], [PaymentOfTax13A], [PaymentOfTax13B], [TotalAmountOfExpense], [Name], [SignatureAndDatePhotoPath], [EmployeementStatus], [Total]) VALUES (14, 10057, N'01-06-2021', N'2020-06-30', N'Preash', N'102030405060', N'216000', N'240000', N'40000', NULL, N'40000', N'75088', N'16000', N'15000', N'30888', N'13200', NULL, N'200000', N'160000', N'40000', NULL, NULL, NULL, N'771088', NULL, NULL, NULL, N'771088', N'Preash', N'~/Images/StatementOfExpensesImages/6b149de5-afa0-4ca5-89ff-09f975399bfd_img_avatar3.png', N'pvt', N'771088')
INSERT [dbo].[StatementOfExpenses] ([Id], [UserId], [AssessmentYear], [StatementDate], [NameOfAssessee], [TIN], [AgriculturalProperty], [HousingExpense], [AutoAndTransportationExpenses07A08B], [DriverSalary07A], [OtherTransportation], [HouseholdAndUtilityExpenses08A08B08C08D], [Electricity08A], [GasWaterSewerAndGarbage08B], [PhoneInternet08C], [HomeSupport08D], [ChildrenEducation], [SpecialExpenses10A10B10C10D], [FestivalParty10A], [DomesticAndOverseasTour10B], [Donation10C], [OtherSpecialExpenses10D], [AnyOtherExpenses], [TotalExpenseRelating], [PaymentOfTax13A13B], [PaymentOfTax13A], [PaymentOfTax13B], [TotalAmountOfExpense], [Name], [SignatureAndDatePhotoPath], [EmployeementStatus], [Total]) VALUES (15, 10058, N'01-06-2021', N'2021-03-02', N'Preash', N'102030405060', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, N'0', N'Preash', N'NOIMAGE_PATH', N'pvt', N'0')
SET IDENTITY_INSERT [dbo].[StatementOfExpenses] OFF
SET IDENTITY_INSERT [dbo].[TaxExempteds] ON 

INSERT [dbo].[TaxExempteds] ([Id], [UserId], [BasicPayTaxExempted], [SpecialPayTaxExempted], [ArrearPayTaxExempted], [DearnessAllowanceTaxExempted], [HouseRentAllowanceTaxExempted], [MedicalAllowanceTaxExempted], [ConveyanceAllowanceTaxExempted], [FestivalAllowanceTaxExempted], [AllowanceStaffTaxExempted], [LeaveAllowanceTaxExempted], [HonorariumTaxExempted], [OvertimeAllowanceExempted], [BonusExempted], [OtherAllowancesExempted], [EmployerContributionExempted], [InterestAccruedExempted], [DeemedIncomeTransportExempted], [DeemedIncomeFurnishedExempted], [OtherIfAnyExempted], [TotalTaxExempted]) VALUES (16, 35, N'0', NULL, NULL, NULL, N'250000', N'50000', NULL, N'0', NULL, NULL, NULL, NULL, N'0', NULL, N'0', NULL, NULL, NULL, N'0', NULL)
INSERT [dbo].[TaxExempteds] ([Id], [UserId], [BasicPayTaxExempted], [SpecialPayTaxExempted], [ArrearPayTaxExempted], [DearnessAllowanceTaxExempted], [HouseRentAllowanceTaxExempted], [MedicalAllowanceTaxExempted], [ConveyanceAllowanceTaxExempted], [FestivalAllowanceTaxExempted], [AllowanceStaffTaxExempted], [LeaveAllowanceTaxExempted], [HonorariumTaxExempted], [OvertimeAllowanceExempted], [BonusExempted], [OtherAllowancesExempted], [EmployerContributionExempted], [InterestAccruedExempted], [DeemedIncomeTransportExempted], [DeemedIncomeFurnishedExempted], [OtherIfAnyExempted], [TotalTaxExempted]) VALUES (17, 10053, N'0', NULL, NULL, NULL, N'197328', N'18000', NULL, N'0', NULL, NULL, NULL, NULL, N'0', NULL, N'0', NULL, NULL, N'0', N'0', NULL)
INSERT [dbo].[TaxExempteds] ([Id], [UserId], [BasicPayTaxExempted], [SpecialPayTaxExempted], [ArrearPayTaxExempted], [DearnessAllowanceTaxExempted], [HouseRentAllowanceTaxExempted], [MedicalAllowanceTaxExempted], [ConveyanceAllowanceTaxExempted], [FestivalAllowanceTaxExempted], [AllowanceStaffTaxExempted], [LeaveAllowanceTaxExempted], [HonorariumTaxExempted], [OvertimeAllowanceExempted], [BonusExempted], [OtherAllowancesExempted], [EmployerContributionExempted], [InterestAccruedExempted], [DeemedIncomeTransportExempted], [DeemedIncomeFurnishedExempted], [OtherIfAnyExempted], [TotalTaxExempted]) VALUES (21, 10054, N'0', NULL, NULL, NULL, N'197328', N'18000', NULL, N'0', NULL, NULL, NULL, NULL, N'0', NULL, N'0', NULL, NULL, NULL, N'0', NULL)
INSERT [dbo].[TaxExempteds] ([Id], [UserId], [BasicPayTaxExempted], [SpecialPayTaxExempted], [ArrearPayTaxExempted], [DearnessAllowanceTaxExempted], [HouseRentAllowanceTaxExempted], [MedicalAllowanceTaxExempted], [ConveyanceAllowanceTaxExempted], [FestivalAllowanceTaxExempted], [AllowanceStaffTaxExempted], [LeaveAllowanceTaxExempted], [HonorariumTaxExempted], [OvertimeAllowanceExempted], [BonusExempted], [OtherAllowancesExempted], [EmployerContributionExempted], [InterestAccruedExempted], [DeemedIncomeTransportExempted], [DeemedIncomeFurnishedExempted], [OtherIfAnyExempted], [TotalTaxExempted]) VALUES (23, 10056, N'0', NULL, NULL, NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[TaxExempteds] ([Id], [UserId], [BasicPayTaxExempted], [SpecialPayTaxExempted], [ArrearPayTaxExempted], [DearnessAllowanceTaxExempted], [HouseRentAllowanceTaxExempted], [MedicalAllowanceTaxExempted], [ConveyanceAllowanceTaxExempted], [FestivalAllowanceTaxExempted], [AllowanceStaffTaxExempted], [LeaveAllowanceTaxExempted], [HonorariumTaxExempted], [OvertimeAllowanceExempted], [BonusExempted], [OtherAllowancesExempted], [EmployerContributionExempted], [InterestAccruedExempted], [DeemedIncomeTransportExempted], [DeemedIncomeFurnishedExempted], [OtherIfAnyExempted], [TotalTaxExempted]) VALUES (24, 10057, N'0', NULL, NULL, NULL, N'197328', N'18000', NULL, N'0', NULL, NULL, NULL, NULL, N'0', NULL, N'0', NULL, NULL, NULL, N'0', NULL)
INSERT [dbo].[TaxExempteds] ([Id], [UserId], [BasicPayTaxExempted], [SpecialPayTaxExempted], [ArrearPayTaxExempted], [DearnessAllowanceTaxExempted], [HouseRentAllowanceTaxExempted], [MedicalAllowanceTaxExempted], [ConveyanceAllowanceTaxExempted], [FestivalAllowanceTaxExempted], [AllowanceStaffTaxExempted], [LeaveAllowanceTaxExempted], [HonorariumTaxExempted], [OvertimeAllowanceExempted], [BonusExempted], [OtherAllowancesExempted], [EmployerContributionExempted], [InterestAccruedExempted], [DeemedIncomeTransportExempted], [DeemedIncomeFurnishedExempted], [OtherIfAnyExempted], [TotalTaxExempted]) VALUES (25, 10058, N'0', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'0', NULL, N'0', N'0', N'1', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TaxExempteds] OFF
SET IDENTITY_INSERT [dbo].[TotalInfoes] ON 

INSERT [dbo].[TotalInfoes] ([Id], [UserId], [Assets], [Expenses], [Slaries], [TaxCredit], [Investment], [Rebate], [Others], [Income]) VALUES (20681, 10057, NULL, N'771088', N'830422', N'292579', NULL, NULL, NULL, NULL)
INSERT [dbo].[TotalInfoes] ([Id], [UserId], [Assets], [Expenses], [Slaries], [TaxCredit], [Investment], [Rebate], [Others], [Income]) VALUES (30688, 10058, NULL, N'0', N'15', N'133915', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[TotalInfoes] OFF
SET IDENTITY_INSERT [dbo].[UserInformations] ON 

INSERT [dbo].[UserInformations] ([Id], [UserId], [AssessmentYear], [NameOfAssessee], [Gender], [NewTIN], [OldTIN], [Circle], [Zone], [TickOnBoxes], [DateOfBirth], [IncomeYearFrom], [IncomeYearTo], [EmployerName], [SpouseName], [SpouseTIN], [FatherName], [MotherName], [PresentAddress], [PermanentAddress], [ContactTelephone], [Email], [NID], [BIN], [ReturnSubmitted], [ResidentStatus], [EmployeementStatus], [VehiclesByOffice], [HouseRentByOffice], [Signature]) VALUES (10047, 10058, N'2021-03-03', N'Preash', N'male', N'102030405060', N'1020304050', N'23', N'23', NULL, N'1994-05-28', N'2020', N'2021', N'Premier University', NULL, NULL, N'Goutam Roy', N'Shopna Roy', N'141, Wasa, Chittagong', N'141, Wasa, Chittagong', N'01871532836', N'towhid.cse2015to@gmail.com', N'1996324343232', NULL, N'No', N'Yes', N'pvt', N'No', N'No', N'~/images/Signatures/9b616afe-5f7a-45f3-98bf-eca897f2da00_wet_digital_signature.jpg')
SET IDENTITY_INSERT [dbo].[UserInformations] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Password], [ConfirmPassword], [IsEmailConfirmed], [Active], [PhotoPath], [EmploymentStatus], [Gender], [IsAutistc], [RecoveryCode], [Bio], [WhoYouAre]) VALUES (10058, N'Md', N'Jane', N'towhid.cse2015to@gmail.com', N'123456', N'123456', 1, 1, N'~/Images/UserImages/20a64727-5e3f-498f-bc84-b54d77c21c20_img_avatar3.png', N'pvt', N'male', 0, NULL, N'Not the answer you''re looking for? Browse other questions tagged ', N'Web App Developer')
SET IDENTITY_INSERT [dbo].[Users] OFF
USE [master]
GO
ALTER DATABASE [TaxationDb] SET  READ_WRITE 
GO
