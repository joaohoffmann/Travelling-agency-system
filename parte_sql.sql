create database atividade02;
use atividade02;
create table Usuarios(
id int auto_increment primary key,
nome varchar(250),
login varchar(250),
senha varchar(250),
dataNascimento datetime
);

create table pacotesTuristicos (
id int auto_increment primary key,
nome varchar(250),
origem varchar(250),
destino varchar(250),
atrativos varchar(250),
saida datetime,
retorno datetime
);


alter table pacotesTuristicos
add column fk_usuarios int;

alter table pacotesTuristicos
add constraint id_fk_usuarios foreign key(fk_usuarios) references Usuarios(id);

describe pacotesTuristicos;

insert into pacotesTuristicos(nome, origem, destino, atrativos, saida, retorno) values('Gruta Azul','Bonito','Bonito','Passeio pela famosa Gruta Azul de agua translúcida',NOW(),NOW());
insert into pacotesTuristicos(nome, origem, destino, atrativos, saida, retorno) values('Boia Cross','Bonito','Bonito','Passeio de boia cross descendo o rio passando por algumas cachoeiras e corredeiras',NOW(),NOW());
insert into pacotesTuristicos(nome, origem, destino, atrativos, saida, retorno) values('Praia do Cassino','Rio Grande','Uruguai','Passeio pela praia do Cassino, com acampamento na praia ate o Uruguai',NOW(),NOW());
insert into pacotesTuristicos(nome, origem, destino, atrativos, saida, retorno) values('Cassino','Uruguai','Uruguai','Cassino de luxo para fazer suas apostas e aproveitar a noite',NOW(),NOW());
insert into pacotesTuristicos(nome, origem, destino, atrativos, saida, retorno) values('Buraco da Arara','Jardim','Jardim','Passeio pelo famoso Buraco da Arará onde se pode ver várias Ararás em seu habitat natural ',NOW(),NOW());
insert into pacotesTuristicos(nome, origem, destino, atrativos, saida, retorno) values('Pacote Praias de Florianópolis','Florianópolis','Florianópolis','Pacote de passeio em 4 praias diferentes incluso almoço.',NOW(),NOW());

select * from usuarios;
select * from pacotesTuristicos;