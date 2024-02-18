CREATE DATABASE Obligatorio2;
USE Obligatorio2;

CREATE TABLE Usuario(idUsr numeric(6) not null,
					 nombreUsr varchar(20) not null,
					 correoUsr varchar(30) not null,
					 contraseñaUsr varchar(20) not null,
					 fechaRegistroUsr date not null,
					 fotoUsr varchar(30),
					 CONSTRAINT PK_Usuario PRIMARY KEY(idUsr),
					 CONSTRAINT AK_NombreUsuario UNIQUE(nombreUsr),
					 CONSTRAINT AK_CorreoUsuario UNIQUE(correoUsr));

CREATE TABLE Sigue(idUsuarioSigue numeric(6) not null,
				   idUsuarioSeguido numeric(6) not null,
				   CONSTRAINT PK_Sigue PRIMARY KEY(idUsuarioSigue, idUsuarioSeguido),
				   CONSTRAINT FK_UsuarioSigue FOREIGN KEY(idUsuarioSigue) REFERENCES Usuario(idUsr),
				   CONSTRAINT FK_UsuarioSeguido FOREIGN KEY(idUsuarioSeguido) REFERENCES Usuario(idUsr));

CREATE TABLE Tecnologia (idTec numeric(6) not null,
						 nombreTec varchar(40) not null,
						 tipo varchar(5)not null,
						 CONSTRAINT PK_Tecnologia PRIMARY KEY(idTec),
						 CONSTRAINT CK_TipoTec CHECK(tipo in ('AA', 'PLN', 'VC', 'O')));

CREATE TABLE Video (idVid numeric (6) not null,
					dscVid varchar(50),
					fechaPublicacionVid date not null,
					duracion numeric(6) not null,
					nroVisitas numeric(10) not null,
					nroMeGusta numeric(8) not null,
					idUsr numeric(6) not null,
					idTec numeric(6) not null,
					CONSTRAINT PK_Video PRIMARY KEY(idVid),
					CONSTRAINT FK_UsrVideo FOREIGN KEY(idUsr) REFERENCES Usuario(idUsr),
					CONSTRAINT FK_TecVideo FOREIGN KEY(idTec) REFERENCES Tecnologia(idTec));

CREATE TABLE Comentario (idComent numeric(6) not null,
						 contenidoComent varchar(50) not null,
						 fechaComent date not null,
						 idUsr numeric(6) not null,
						 idVid numeric(6) not null,
						 CONSTRAINT PK_Comentario PRIMARY KEY(idComent),
						 CONSTRAINT FK_UsrComentario FOREIGN KEY(idUsr) REFERENCES Usuario(idUsr),
						 CONSTRAINT FK_VidComentario FOREIGN KEY(idVid) REFERENCES Video(idVid));

CREATE TABLE Comunidad (nombreCom varchar(30) not null,
						dscCom varchar(50) not null,
						CONSTRAINT PK_Comunidad PRIMARY KEY(nombreCom));

CREATE TABLE Pertenece (nombreCom varchar(30) not null,
						idUsr numeric(6) not null,
						CONSTRAINT PK_Pertenece PRIMARY KEY(nombreCom, idUsr),
						CONSTRAINT FK_UsrPertenece FOREIGN KEY(idUsr) REFERENCES Usuario(idUsr),
						CONSTRAINT FK_ComPertenece FOREIGN KEY(nombreCom) REFERENCES Comunidad(nombreCom));