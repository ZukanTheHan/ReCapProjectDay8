Create Table Brand(
		Id int primary key identity(1,1),
		BrandName nvarchar (50),

)

Create Table Color(
		ColorId int primary key identity(1,1),
		ColorName nvarchar (50),

)

Create Table Car(
		Id int primary key identity (1,1),
		BrandId int,
		ColorId int,
		ModelYear int,
		DailyPrice decimal,
		Descriptions nvarchar (50)
		Foreign key (BrandId) references Brand(BrandId),
		Foreign key (ColorId) references Color(ColorId)
)



