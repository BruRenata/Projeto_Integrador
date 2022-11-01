#criar data base api_medicos; 

create database api_medicos;
use api_medicos;

#tabela medicos com id e nome CRM e CPF

create table medicos
(
id int not null auto_increment primary key, 
nome VARCHAR(100) not null,
CRM VARCHAR(12) not null, 
CPF VARCHAR(11) not null
);

#tabela pacientes id e nome
create table pacientes
(
id int not null auto_increment primary key, 
nome VARCHAR(100) not null, 
CPF VARCHAR(11) not null
);

#adicionando manualmente médicos
insert into medicos (nome, CRM, CPF) values ("Joaquim Carceles", "CRM/SC123456", "05488806740");
insert into medicos (nome, CRM, CPF) values ("Maria Joaquina", "CRM/SC123457", "05488846740");


#adicionando manualmente pacientes
insert into pacientes (nome, CPF) values ("Carolina Amaral", "05488846770");
insert into pacientes (nome, CPF) values ("João Figueiredo", "05788846740");
insert into pacientes (nome, CPF) values ("Rubia Branco Celoto", "05968846740");

create table atendentes
(
id int not null auto_increment primary key, 
nome VARCHAR(100) not null,
CPF VARCHAR(11) not null
);

#adicionando manualmente atendentes
insert into atendentes (nome, CPF) values ("Bianca Mondi", "05968846430");
insert into atendentes (nome, CPF) values ("Joana Tramontini", "05966646740");


#criando tabela de consultas
create table consultas
(
id INT NOT NULL auto_increment primary key, 
paciente_id int, 
medico_id int, 
observacao varchar(250) not null, 
data_consulta date not null, 
constraint fk_medico foreign key (medico_id) references medicos(id),
constraint fk_paciente foreign key (paciente_id) references pacientes(id)
);


#criando tabela de exames
create table exames
(
id int not null auto_increment primary key, 
tipo VARCHAR(100) not null,
descricao varchar(300), 
consulta_id int(11),
constraint consulta_id foreign key (consulta_id) references consultas(id)
);



#adicionando consultas manualmente
insert into consultas (paciente_id, medico_id, data_consulta, observacao) values (1, 2,'2022-08-23', 'Paciente está com fraqueza, realizar exame de sangue');

#"insert into exames (nome) values (@nome)";
insert into exames (tipo, descricao, consulta_id) values ("sangue", "Hemograma; Colesterol; Triglicerídeos; Glicemia;", 1);


#insert into consultas 
#set paciente_id = 2, medico_id = 2, data_consulta = '23-08-2022';

#"update exames set tipo = @tipo,  where id = @Id";
update exames 
set tipo = "fezes", descricao = "vermes" where id = 1;

select *from consultas; 


#string sql = "select * from exames"; mais pedidos
 select tipo as "Exames mais realizados", count(tipo) as "Quantidade"
 from exames 
 group by tipo 
 order by count(tipo) desc;
 
 
 #string sql = "select * from exames"; menos pedidos
 select tipo as 'Exames menos realizados', count(tipo) as 'Quantidade' from exames group by tipo order by count(tipo) 










