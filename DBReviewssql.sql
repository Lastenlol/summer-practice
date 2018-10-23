use master
go

if exists(select *
          from sys.databases
          where [name] = 'Reviews')
  begin
    drop database Reviews
  end

create database Reviews
use Reviews


create table [User] (
  Id         int identity (1, 1) not null constraint [UserPK] primary key,
  [Name]     varchar(255)        not null,
  [Password] varchar(100)        not null,
  [Role]     int                 not null
)

create table Review (
  Id      int identity (1, 1) not null constraint [ReviewPK] primary key,
  UserId  int                 not null,
  [Name]  varchar(255)        not null,
  Comment varchar(300)        not null
)

alter table [Review]
  add constraint [FK_Review_User] foreign key ([UserId]) references [User] ([Id])
  on delete cascade
  on update cascade


-- stored procedures

set ansi_nulls on
set quoted_identifier on

create procedure AddUser
    @name     varchar(255),
    @password varchar(100),
    @role     int
as
  begin
    insert INTO [User] ([Name], [Role], [Password]) VALUES (@name, @role, @password)

    select scope_identity()
  end
go


create procedure GetUsers
as
  begin
    select * FROM [User]
  end
go


create procedure AddReview
    @UserId  int,
    @name    varchar(255),
    @comment varchar(300)
as
  begin
    insert into [Review] ([Name], [Comment], [UserId]) VALUES (@name, @comment, @UserId)

    select scope_identity()
  end
go


create procedure GetReviews
as
  begin
    select * FROM [Review]
  end
go


create procedure GetUserById
    @id int
as
  begin
    select * FROM [User] where Id = @id
  end
go


create procedure GetReviewById
    @id int
as
  begin
    select * FROM [Review] where Id = @id
  end
go


create procedure UpdateUserForUsers
    @id   int,
    @name varchar(255)
as
  begin
    update [User] set [Name] = @name where Id = @id
  end
go


create procedure UpdateUserForAdmin
    @id   int,
    @ROLE int
as
  begin
    update [User] set [Role] = @ROLE where Id = @id
  end
go


create procedure UpdateReview
    @id      int,
    @name    varchar(255),
    @comment varchar(300)
as
  begin
    update [Review]
    set [Name]    = @name,
        [Comment] = @comment
    where Id = @id
  end
go


create procedure DeleteUser
    @id int
as
  begin
    delete from [User] where Id = @id
  end
go


create procedure DeleteReview
    @id int
as
  begin
    delete from Review where Id = @id
  end

  set ansi_nulls on
  set quoted_identifier on

  create procedure GetAllReviewsForUser
      @userId int
  as
    begin
      select * from Review where UserId = @userId
    end
go