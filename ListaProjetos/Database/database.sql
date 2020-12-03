create database ListaProjetos
go

use ListaProjetos
go

create table tblProjeto (
    codProjeto int identity not null,
    codStatus int not null,
    codTag int,
    titulo varchar(70) not null,
    descricao varchar(200),
)
go

create table tblUsuario (
    codUsuario int identity not null,
    nome varchar(70) not null,
    username varchar(70),
    email varchar(70) not null,
    senha varchar(70) not null,
    imagem varbinary,
    linkWebsite varchar(70),
    localizacao varchar(70)
)
go

create table tblStatus (
    codStatus int identity not null,
    descricao varchar(200)
)
go

create table tblTag (
    codTag int identity not null,
    descricao varchar(200)
)
go

create table tblProjetoUsuario (
    codProjeto int not null,
    codUsuario int not null
)
go

create index XPROJETO on tblProjeto (codProjeto)
create index XUSUARIO on tblUsuario (codUsuario)
create index XSTATUS on tblStatus (codStatus)
create index XTAG on tblTag (codTag)
create index XFOLLOW on tblFollow (codFollow)
go

alter table tblProjeto add constraint pk_projeto primary key (codProjeto)
alter table tblUsuario add constraint pk_usuario primary key (codUsuario)
alter table tblStatus add constraint pk_status primary key (codStatus)
alter table tblTag add constraint pk_tag primary key (codTag)
alter table tblFollow add constraint pk_follow primary key (codFollow)
go

alter table tblProjeto add constraint fk_projeto_stats foreign key (codStatus) references tblStatus (codStatus)
alter table tblProjeto add constraint fk_projeto_tags foreign key (codTag) references tblTag (codTag)
alter table tblProjetoUsuario add constraint fk_projetoUsuario_projeto foreign key (codProjeto) references tblProjeto (codProjeto)
alter table tblProjetoUsuario add constraint fk_projetoUsuario_usuario foreign key (codUsuario) references tblUsuario (codUsuario)go

insert into tblStatus values ('Public'), ('Private')
go

insert into tblTag values ('javascript'), ('color'), ('generator'), ('password'), ('winforms'), ('aspx'), ('api'), ('csharp'), ('html'), ('css'), ('travel'), ('tcm'), ('dark-theme')