use [EmployeeDB];


create table Employees (
	Name varchar(100) unique,
	Mobile bigint unique check (len(Mobile) = 10),
	Email varchar(100),
	DOB date,
	Designation varchar(3) check (Designation in ('HO', 'RBM', 'CSM', 'CSE'))
);




truncate table Employees

--go
--alter procedure usp_Insert_Update_Employee (
--	@Name varchar(100),
--	@Mobile bigint,
--	@Email varchar(100),
--	@DOB date,
--	@Designation varchar(3)
--) 
--as
--begin
--	if object_id('Employees') is null
--	begin
--		create table Employees (
--			Name varchar(100) unique,
--			Mobile bigint unique check (len(Mobile) = 10),
--			Email varchar(100),
--			DOB date,
--			Designation varchar(3) check (Designation in ('HO', 'RBM', 'CSM', 'CSE'))
--		);

--	end;

--	if exists (
--		select *
--		from Employees
--		where Name = @Name
--	)
--	begin
--		exec usp_Delete_Employee @Name;
--	end;

--	insert into Employees
--	values
--	(@Name, @Mobile, @Email, @DOB, @Designation);
--end;
--go



go
alter procedure usp_Insert_Employee (
	@Name varchar(100),
	@Mobile bigint,
	@Email varchar(100),
	@DOB date,
	@Designation varchar(3)
) 
as
begin
	if object_id('Employees') is null
	begin
		create table Employees (
			Name varchar(100) unique,
			Mobile bigint unique check (len(Mobile) = 10),
			Email varchar(100),
			DOB date,
			Designation varchar(3) check (Designation in ('HO', 'RBM', 'CSM', 'CSE'))
		);

	end;

	insert into Employees
	values
	(@Name, @Mobile, @Email, @DOB, @Designation);
end;
go



go
alter procedure usp_Delete_Employee (
	@Name varchar(100)
)
as 
begin
	if exists (
		select *
		from Employees
		where Name = @Name
	)
	begin
		delete from Employees
		where Name = @Name
	end;
	else
	begin
		raiserror('Record doesn''t exist', 16, 1); 
	end
end;
go





go
alter procedure usp_Get_Employee (
	@Name varchar(100) = null
)
as
begin
	if object_id('Employees') is null
	begin
		create table Employees (
			Name varchar(100) unique,
			Mobile bigint unique check (len(Mobile) = 10),
			Email varchar(100),
			DOB date,
			Designation varchar(3) check (Designation in ('HO', 'RBM', 'CSM', 'CSE'))
		);
		select * 
		from Employees 
		order by 
		case
			when Designation = 'HO' then 1
			when Designation = 'RBM' then 2
			when Designation = 'CSM' then 3
			when Designation = 'CSE' then 4
		end, Name
	end;

	else if @Name is null
	begin
		select * 
		from Employees 
		order by 
		case
			when Designation = 'HO' then 1
			when Designation = 'RBM' then 2
			when Designation = 'CSM' then 3
			when Designation = 'CSE' then 4
		end, Name
	end

	else if @Name is not null and not exists (select * from Employees where Name = @Name) or object_id('Employees') is null
	begin
		raiserror('Record doesn''t exist', 16, 1);
	end

	else
	begin
		select * 
		from Employees 
		where Name = @Name
	end
end;
go


--go
--create procedure usp_Update_Employee (
--	@Field varchar(100),
--	@oldVal varchar(100),
--	@newVal varchar(100)
--)
--as
--begin

--end
--go





select * 
from Employees
order by 
case
	when Designation = 'HO' then 1
	when Designation = 'RBM' then 2
	when Designation = 'CSM' then 3
	when Designation = 'CSE' then 4
end, Name;

delete from Employees
where Name = 'Sandhya' or Mobile = 9222052650

drop table Employees

exec usp_Insert_Update_Employee 'Shreyas', 9820819316, 'shreyas@gmail.com', '2022-10-02', 'CSE';
exec usp_Insert_Update_Employee 'Rajesh', 9820589316, 'rajesh@gmail.com', '2022-10-02', 'CSE';
exec usp_Insert_Update_Employee 'Sandhya', 9222052650, 'sandhya@gmail.com', '2022-10-02', 'CSM';

exec usp_Delete_Employee 'Shreyas';
exec usp_Get_Employee;




