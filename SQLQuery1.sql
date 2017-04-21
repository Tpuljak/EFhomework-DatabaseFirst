create database Game

create table Player (
	PlayerId int identity,
	primary key (PlayerId),
	Username nvarchar(max),
	Password nvarchar(max),
	Email nvarchar(max),
	MMR int,

)

create table Match (
	MatchId int identity,
	primary key(MatchId),
	Name nvarchar(max),

)

create table Mission (
	MissionId int identity,
	primary key(MissionId),
	Name nvarchar(max),
	Text nvarchar(max),
	MatchId int foreign key references Match(MatchId)
)

create table Player_Match (
	PlayerId int foreign key references Player(PlayerId) not null,
	MatchId int foreign key references Match(MatchId) not null	
)

insert into Match (Name)
values ('First Match')

insert into Match (Name)
values ('Second Match')

insert into Match (Name)
values ('Third Match')