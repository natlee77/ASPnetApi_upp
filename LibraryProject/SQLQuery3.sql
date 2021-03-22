CREATE TABLE  Managers  (
    Id int not null identity(1,1) primary key,
    FirstName    NVARCHAR (50)   NOT NULL,
    LastName     NVARCHAR (50)   NOT NULL,
    Email        VARCHAR (100)   NOT NULL,
    PasswordHash VARBINARY (MAX) NOT NULL,
    PasswordSalt VARBINARY (MAX) NOT NULL,

    
);
CREATE TABLE Customers(
	Id int not null identity(1,1) primary key,
	FirstName nvarchar(50) not null,
	LastName  nvarchar(50) not null,
	Email     varchar(100) not null
);

CREATE TABLE SessionsTokens  (
     
	ManagerId int not null primary key	references Managers(Id),
    AccessToken nvarchar (MAX) NOT NULL,

     
);	


GO

CREATE TABLE Issues(
	Id int not null identity(1,1) primary key,
	CustomerId      int not null references Customers(Id),
	ManagerId int not null references Managers(Id),
	IssueDate   datetime2 not null,
	ResolveDate datetime2 null,
	IssueDescription nvarchar(max) not null,
	IssueStatus      nvarchar(20) not null
)