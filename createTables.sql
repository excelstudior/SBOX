Use SBOX

create table Share (
	Code nvarchar(10) primary key,
	Name nvarchar(100),
	Sector nvarchar(25),
	MarketVaule int,
	Label nvarchar(20)
)
go

create table HistorySummary(
	Id uniqueidentifier primary key,
	Code nvarchar(10) foreign key references Share(Code),
	[Date] datetime,
	[Open] decimal (18,2),
	[High] decimal (18,2),
	[Low] decimal (18,2),
	[Close] decimal (18,2),
	[Volume] bigint

)
GO

create table DailyCourse(
	Id uniqueidentifier primary key,
	Code nvarchar(10) foreign key references Share(Code),
	[ActionTime] datetime,
	[Price] decimal (18,2),
	[Volume] bigint 
)
Go