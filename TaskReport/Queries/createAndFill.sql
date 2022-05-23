create table reports (
ID Integer primary key,
exportName varchar(50),
DateAndTime datetime,
userName varchar(50),
placeName varchar(50)
)

declare @i int = 1;
declare @name varchar(max) = 'eksport';
declare @dateTime date = convert(datetime, '2022-04-23 11:45');
declare @username varchar(max) = 'user';
declare @placeName varchar(max) = 'lokal';
declare @placeNumber integer = 1;

while (@i < 10)
begin

declare @n varchar(max) = @name + CONVERT(varchar, @i);
declare @d datetime = dateadd(day, @i, @dateTime);
set @d = dateadd(hour, @i, @d);
declare @u varchar(max) = @username + CONVERT(varchar, @i);
declare @p varchar(max) = @placeName + CONVERT(varchar, @placeNumber);

insert into reports values (@i, @n, @d, @u, @p);

if (@i > 5)
begin
set @placeNumber = 2;
end

set @i = @i + 1;

end;

select * from reports;
