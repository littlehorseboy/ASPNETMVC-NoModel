# ASPNETMVC-NoModel
以不使用 LINQ 為目標的開發方式

資料庫用 SQLEXPRESS
其他內容看 Web.config 連線字串應該就知道了

/*    ==指令碼參數==

    來源伺服器版本 : SQL Server 2016 (13.0.4206)
    來源資料庫引擎版本 : Microsoft SQL Server Express Edition
    來源資料庫引擎類型 : 獨立 SQL Server

    目標伺服器版本 : SQL Server 2016
    目標資料庫引擎版本 : Microsoft SQL Server Express Edition
    目標資料庫引擎類型 : 獨立 SQL Server
*/

```sql
USE [test20180421]
GO

/****** Object:  Table [dbo].[CRUD]    Script Date: 2018/4/21 下午 01:59:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CRUD](
	[id] [varchar](36) NOT NULL,
	[name] [nvarchar](50) NULL,
	[city] [nvarchar](50) NULL,
 CONSTRAINT [PK_CRUD] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
```
