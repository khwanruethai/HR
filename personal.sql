USE [PersonalDB]
GO
/****** Object:  Table [dbo].[old_department]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[old_department](
	[id] [float] NULL,
	[Code] [nvarchar](255) NULL,
	[Code_Sec] [nvarchar](255) NULL,
	[Department] [nvarchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_amphur]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_amphur](
	[amphur_id] [int] IDENTITY(1,1) NOT NULL,
	[amphur_code] [nvarchar](4) NULL,
	[amphur_name] [nvarchar](150) NULL,
	[amphur_ref_geo_id] [int] NULL,
	[amphur_ref_province_id] [int] NULL,
 CONSTRAINT [PK_personal_amphur] PRIMARY KEY CLUSTERED 
(
	[amphur_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_company]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_company](
	[comp_id] [int] NOT NULL,
	[code_comp] [varchar](3) NULL,
	[T_Company] [varchar](50) NULL,
	[E_Company] [varchar](50) NULL,
	[Address] [varchar](255) NULL,
	[addr_no] [varchar](50) NULL,
	[addr_moo] [varchar](50) NULL,
	[addr_lane] [varchar](50) NULL,
	[addr_road] [varchar](50) NULL,
	[addr_district] [varchar](50) NULL,
	[addr_amphur] [varchar](50) NULL,
	[addr_province] [varchar](50) NULL,
	[Tel] [varchar](50) NULL,
	[Code_Bank] [varchar](3) NULL,
	[No_Bank] [varchar](50) NULL,
	[No_Tax] [varchar](50) NULL,
	[No_Social] [varchar](50) NULL,
	[Name_Board] [varchar](50) NULL,
	[Post_Board] [varchar](50) NULL,
 CONSTRAINT [PK_tab_company] PRIMARY KEY CLUSTERED 
(
	[comp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_department]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_department](
	[dept_id] [int] NOT NULL,
	[dept_name] [varchar](50) NULL,
 CONSTRAINT [PK_tab_department] PRIMARY KEY CLUSTERED 
(
	[dept_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_department_list]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_department_list](
	[dept_list_id] [int] IDENTITY(1,1) NOT NULL,
	[comp_id] [int] NULL,
	[section_id] [int] NULL,
	[dept_id] [int] NULL,
 CONSTRAINT [PK_tab_department_list] PRIMARY KEY CLUSTERED 
(
	[dept_list_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_district]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_district](
	[district_id] [int] IDENTITY(1,1) NOT NULL,
	[district_code] [nvarchar](6) NULL,
	[district_name] [nvarchar](150) NULL,
	[district_ref_ampur_id] [int] NULL,
	[district_ref_province_id] [int] NULL,
	[district_ref_geo_id] [int] NULL,
 CONSTRAINT [PK_personal_district] PRIMARY KEY CLUSTERED 
(
	[district_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_emp_address]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_emp_address](
	[address_id] [int] IDENTITY(1,1) NOT NULL,
	[address_num] [varchar](50) NULL,
	[address_moo] [varchar](50) NULL,
	[address_type] [varchar](50) NULL,
	[address_name] [varchar](50) NULL,
	[address_alley] [varchar](50) NULL,
	[address_road] [varchar](50) NULL,
	[address_district_id] [varchar](50) NULL,
	[address_amphur_id] [varchar](50) NULL,
	[address_province_id] [varchar](50) NULL,
	[address_postcode] [varchar](50) NULL,
	[address_num_call] [varchar](50) NULL,
	[address_moo_call] [varchar](50) NULL,
	[address_type_call] [varchar](50) NULL,
	[address_name_call] [varchar](50) NULL,
	[address_alley_call] [varchar](50) NULL,
	[address_road_call] [varchar](50) NULL,
	[address_district_id_call] [varchar](50) NULL,
	[address_amphur_id_call] [varchar](50) NULL,
	[address_province_id_call] [varchar](50) NULL,
	[address_postcode_call] [varchar](50) NULL,
	[address_ref_emp_id] [int] NULL,
	[address_ref_admin_id] [int] NULL,
	[address_submit_date] [datetime] NULL,
 CONSTRAINT [PK_tab_address_emp] PRIMARY KEY CLUSTERED 
(
	[address_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_emp_contact]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_emp_contact](
	[contact_id] [int] IDENTITY(1,1) NOT NULL,
	[contact_email] [text] NULL,
	[contact_table] [varchar](50) NULL,
	[contact_phone] [varchar](50) NULL,
	[contact_mobile1] [varchar](50) NULL,
	[contact_mobile2] [varchar](50) NULL,
	[contact_emp_id] [int] NULL,
	[contact_admin_id] [int] NULL,
	[contact_submit_date] [datetime] NULL,
	[contact_status] [varchar](10) NULL CONSTRAINT [DF_tab_contact_emp_contact_status]  DEFAULT ('OPEN'',''DELETE'),
 CONSTRAINT [PK_tab_contact_emp] PRIMARY KEY CLUSTERED 
(
	[contact_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_emp_family]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_emp_family](
	[family_id] [int] NOT NULL,
	[family_relation1] [nvarchar](50) NULL,
	[family_name1] [nvarchar](255) NULL,
	[family_age1] [int] NULL,
	[family_address1] [text] NULL,
	[family_tel1] [nvarchar](10) NULL,
	[family_relation2] [nvarchar](50) NULL,
	[family_name2] [nvarchar](255) NULL,
	[family_age2] [int] NULL,
	[family_address2] [text] NULL,
	[family_tel2] [nvarchar](10) NULL,
	[family_relation3] [nvarchar](50) NULL,
	[family_name3] [nvarchar](255) NULL,
	[family_age3] [int] NULL,
	[family_address3] [text] NULL,
	[family_tel3] [nvarchar](10) NULL,
	[family_emergency_name] [nvarchar](255) NULL,
	[family_emergency_relation] [nvarchar](50) NULL,
	[family_emergency_tel] [nvarchar](10) NULL,
	[family_emp_id] [int] NULL,
	[family_admin_id] [int] NULL,
	[family_submit_date] [datetime] NULL,
	[family_status] [varchar](50) NULL,
 CONSTRAINT [PK_tab_emp_family] PRIMARY KEY CLUSTERED 
(
	[family_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_emp_pay]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_emp_pay](
	[pay_id] [int] IDENTITY(1,1) NOT NULL,
	[pay_ref_income_id] [int] NULL,
	[pay_amount] [float] NULL,
	[pay_ref_emp_id] [int] NULL,
	[pay_admin_id] [int] NULL,
	[pay_submit_date] [datetime] NULL,
 CONSTRAINT [PK_tab_emp_pay] PRIMARY KEY CLUSTERED 
(
	[pay_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_emp_position]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_emp_position](
	[position_id] [int] NOT NULL,
	[position_emp_id] [int] NULL,
	[position_comp_id] [int] NULL,
	[position_sect_id] [int] NULL,
	[position_dept_id] [int] NULL,
	[position_posit_id] [int] NULL,
	[position_type] [varchar](50) NULL,
	[position_start_date] [date] NULL,
	[position_resign_date] [date] NULL,
	[position_admin_id] [int] NULL,
	[position_submit_date] [datetime] NULL,
	[position_status] [varchar](50) NULL,
 CONSTRAINT [PK_tab_emp_position] PRIMARY KEY CLUSTERED 
(
	[position_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_emp_profile]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_emp_profile](
	[profile_id] [int] IDENTITY(1,1) NOT NULL,
	[profile_gender] [varchar](6) NULL CONSTRAINT [DF_tab_profile_emp_profile_gender]  DEFAULT ('''F'',''M'''),
	[profile_birthday] [date] NULL,
	[profile_age] [int] NULL,
	[profile_nationality] [varchar](50) NULL,
	[profile_race] [varchar](50) NULL,
	[profile_religion] [varchar](50) NULL,
	[profile_blood] [varchar](50) NULL,
	[profile_identification] [varchar](50) NULL,
	[profile_date_issue] [date] NULL,
	[profile_expired_date] [date] NULL,
	[profile_weigth] [varchar](50) NULL,
	[profile_height] [varchar](50) NULL,
	[profile_marital_status] [varchar](50) NULL CONSTRAINT [DF_tab_profile_emp_profile_marital_status]  DEFAULT ('single","marry","divorce","separate'),
	[profile_child_num] [int] NULL,
	[profile_emp_id] [int] NULL,
	[profile_admin_id] [int] NULL,
	[profile_submit_date] [datetime] NULL,
	[profile_status] [varchar](50) NULL CONSTRAINT [DF_tab_profile_emp_profile_status]  DEFAULT ('"OPEN","DELETE"'),
 CONSTRAINT [PK_tab_profile_emp] PRIMARY KEY CLUSTERED 
(
	[profile_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_emp_skill]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_emp_skill](
	[skill_id] [int] NOT NULL,
	[skill_name] [text] NULL,
	[skill_emp_id] [int] NULL,
	[skill_admin_id] [int] NULL,
	[skill_submit_date] [datetime] NULL,
 CONSTRAINT [PK_tab_skill] PRIMARY KEY CLUSTERED 
(
	[skill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_emp_type]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_emp_type](
	[type_id] [int] IDENTITY(1,1) NOT NULL,
	[type_name] [varchar](200) NULL,
	[type_submit_date] [datetime] NULL,
	[type_admin_id] [int] NULL,
 CONSTRAINT [PK_tab_emp_type] PRIMARY KEY CLUSTERED 
(
	[type_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_employee]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_employee](
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_code] [varchar](50) NULL,
	[emp_prefix] [varchar](50) NULL,
	[emp_name_th] [text] NULL,
	[emp_name_en] [text] NULL,
	[emp_status] [varchar](50) NULL,
	[emp_type] [varchar](50) NULL,
	[emp_start_date] [date] NULL,
	[emp_end_date] [date] NULL,
	[emp_admin_id] [int] NULL,
	[emp_submit_date] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_geography]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_geography](
	[geo_id] [int] IDENTITY(1,1) NOT NULL,
	[geo_name] [nvarchar](255) NULL,
 CONSTRAINT [PK_personal_geography] PRIMARY KEY CLUSTERED 
(
	[geo_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_info_fund]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_info_fund](
	[fund_id] [int] IDENTITY(1,1) NOT NULL,
	[fund_name] [varchar](200) NULL,
	[fund_submit_date] [datetime] NULL,
	[fund_admin_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[fund_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_info_income]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_info_income](
	[income_id] [int] IDENTITY(1,1) NOT NULL,
	[income_name] [varchar](200) NULL,
	[income_submit_date] [datetime] NULL,
	[income_admin_id] [int] NULL,
 CONSTRAINT [PK_tab_info_income] PRIMARY KEY CLUSTERED 
(
	[income_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_info_minus]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_info_minus](
	[minus_id] [int] IDENTITY(1,1) NOT NULL,
	[minus_name] [varchar](200) NULL,
	[minus_submit_date] [datetime] NULL,
	[minus_admin_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[minus_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_info_prefix]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_info_prefix](
	[prefix_id] [int] IDENTITY(1,1) NOT NULL,
	[prefix_name_th] [varchar](50) NULL,
	[prefix_name_en] [varchar](50) NULL,
	[prefix_submit_date] [datetime] NULL,
	[prefix_admin_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[prefix_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_info_status]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_info_status](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[status_name] [varchar](200) NULL,
	[status_submit_date] [datetime] NULL,
	[status_admin_id] [int] NULL,
 CONSTRAINT [PK_tab_info_status] PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tab_province]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tab_province](
	[province_id] [int] IDENTITY(1,1) NOT NULL,
	[province_code] [nvarchar](2) NULL,
	[province_name] [nvarchar](150) NULL,
	[geo_id] [int] NULL,
 CONSTRAINT [PK_personal_province] PRIMARY KEY CLUSTERED 
(
	[province_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tab_section]    Script Date: 27/10/2560 16:57:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tab_section](
	[section_id] [int] NOT NULL,
	[section_Code] [varchar](3) NULL,
	[Section_name] [varchar](50) NULL,
	[Code_Comp] [varchar](3) NULL,
 CONSTRAINT [PK_tab_section] PRIMARY KEY CLUSTERED 
(
	[section_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[tab_emp_family] ADD  CONSTRAINT [DF_tab_emp_family_family_status]  DEFAULT ('("OPEN","DELETE")') FOR [family_status]
GO
ALTER TABLE [dbo].[tab_emp_position] ADD  CONSTRAINT [DF_tab_emp_position_position_type]  DEFAULT ('("day","temporary","month")') FOR [position_type]
GO
ALTER TABLE [dbo].[tab_emp_position] ADD  CONSTRAINT [DF_tab_emp_position_position_status]  DEFAULT ('("OPEN","DELETE")') FOR [position_status]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id อำเภอ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_amphur', @level2type=N'COLUMN',@level2name=N'amphur_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสอำเภอ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_amphur', @level2type=N'COLUMN',@level2name=N'amphur_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่ออำเภอ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_amphur', @level2type=N'COLUMN',@level2name=N'amphur_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ref id ภูมิภาค' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_amphur', @level2type=N'COLUMN',@level2name=N'amphur_ref_geo_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ref id จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_amphur', @level2type=N'COLUMN',@level2name=N'amphur_ref_province_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ตำบล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_district', @level2type=N'COLUMN',@level2name=N'district_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสตำบล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_district', @level2type=N'COLUMN',@level2name=N'district_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อตำบล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_district', @level2type=N'COLUMN',@level2name=N'district_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ref id อำเภอ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_district', @level2type=N'COLUMN',@level2name=N'district_ref_ampur_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ref id จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_district', @level2type=N'COLUMN',@level2name=N'district_ref_province_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ref id ภูมิภาค' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_district', @level2type=N'COLUMN',@level2name=N'district_ref_geo_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน เลขที่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_num'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน หมู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_moo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน ประเภทที่พัก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน ชื่อที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน  ซอย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_alley'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน ถนน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_road'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน id ตำบล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_district_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน id อำเภอ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_amphur_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน id จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_province_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ตามทะเบียนบ้าน id รหัสไปรษณีย์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_postcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ เลขที่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_num_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ หมู่ที่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_moo_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ ประเภทที่พัก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_type_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ ชื่อที่อยู่' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_name_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ ซอย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_alley_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ ถนน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_road_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ id ตำบล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_district_id_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ id อำเภอ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_amphur_id_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ id จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_province_id_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ที่อยู่ติดต่อได้ รหัสไปรษณีย์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_postcode_call'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id พนักงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_ref_emp_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ผู้บันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_ref_admin_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วัน/เวลาบันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_address', @level2type=N'COLUMN',@level2name=N'address_submit_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id การติดต่อ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'อีเมล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_email'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'เบอร์โต๊ะ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_table'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'โทรศัพท์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'มือถือ1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_mobile1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'มือถือ2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_mobile2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id พนักงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_emp_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ผู้บันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_admin_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วัน/เวลบันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_submit_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะ(เปิด/ลบ)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_contact', @level2type=N'COLUMN',@level2name=N'contact_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id บุคคลที่เกี่ยวข้อง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_family', @level2type=N'COLUMN',@level2name=N'family_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความสัมพันธ์' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_family', @level2type=N'COLUMN',@level2name=N'family_relation1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_family', @level2type=N'COLUMN',@level2name=N'family_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ข้อมูลตำแหน่งงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'รหัสพนักงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_emp_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id บริษัท' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_comp_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ฝ่าย' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_sect_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id แผนก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_dept_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ตำแหน่ง' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_posit_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ประเภท (รายวัน/ชั่วคราว/รายเดือน)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่เริ่มงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_start_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่ลาออก' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_resign_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ผู้บันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_admin_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่บันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_submit_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'สถานะข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_position', @level2type=N'COLUMN',@level2name=N'position_status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ความสามารถ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_skill', @level2type=N'COLUMN',@level2name=N'skill_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ความสามารถ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_skill', @level2type=N'COLUMN',@level2name=N'skill_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id พนักงาน' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_skill', @level2type=N'COLUMN',@level2name=N'skill_emp_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ผู้บันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_skill', @level2type=N'COLUMN',@level2name=N'skill_admin_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'วันที่บันทึกข้อมูล' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_emp_skill', @level2type=N'COLUMN',@level2name=N'skill_submit_date'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id ภูมิภาค' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_geography', @level2type=N'COLUMN',@level2name=N'geo_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ชื่อภูมิภาค' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_geography', @level2type=N'COLUMN',@level2name=N'geo_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'id จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_province', @level2type=N'COLUMN',@level2name=N'province_id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'code จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_province', @level2type=N'COLUMN',@level2name=N'province_code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'จังหวัด' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_province', @level2type=N'COLUMN',@level2name=N'province_name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ref idภูมิภาค' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tab_province', @level2type=N'COLUMN',@level2name=N'geo_id'
GO
