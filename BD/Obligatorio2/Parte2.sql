/*PARTE 2 DEL OBLIGATORIO 2*/

set dateformat ymd;

/*Ejercicio 1*/
select top 10 u.idUsr, u.nombreUsr, u.fotoUsr, u.fechaRegistroUsr, u.correoUsr, u.contraseñaUsr
from Usuario u, Video v, Comentario c
where u.idUsr = v.idUsr and
	  c.idVid = v.idVid
group by u.idUsr, u.nombreUsr, u.fotoUsr, u.fechaRegistroUsr, u.correoUsr, u.contraseñaUsr
order by count(c.idComent) DESC;

/*Ejercicio 2*/
select com.dscCom, com.nombreCom, u.nombreUsr, c.contenidoComent, v.dscVid, t.nombreTec
from Comunidad com, Pertenece p, Comentario c, Video v, Tecnologia t, Usuario u
where com.nombreCom = p.nombreCom and
	  p.idUsr = u.idUsr and
	  c.idUsr = u.idUsr and
	  c.idVid = v.idVid and
	  v.idTec = t.idTec;

/*Ejercicio 3*/
select com.nombreCom, count(p.idUsr) as CantUsuarios
from Comunidad com, Usuario u, Pertenece p, Video v, Comentario c
where com.nombreCom = p.nombreCom and
	  p.idUsr = u.idUsr and
	  v.idUsr = u.idUsr and
	  v.idVid = c.idVid
group by com.nombreCom, u.nombreUsr
having count(p.idUsr) > 10
order by cantUsuarios DESC;

/*Ejercicio 4*/
select p.nombreCom, u.nombreUsr, count(v.idVid) as CantVideos
from Usuario u, Video v, Comunidad c, Pertenece p
where u.idUsr = p.idUsr and
	  p.nombreCom = c.nombreCom and
	  v.idUsr = u.idUsr
group by p.nombreCom, u.nombreUsr
having count(v.idVid) >= 10
order by CantVideos DESC;


/*Ejercicio 5*/
select u.nombreUsr, c.contenidoComent, v.dscVid
from Usuario u, Comentario c, Video v, Tecnologia t
where u.idUsr = c.idUsr and
	  c.idVid = v.idVid and 
	  v.idTec = t.idTec and
	  t.nombreTec = 'Visión por Computadora' and (c.contenidoComent like '%deep learning%' or c.contenidoComent like '%redes neuronales%');

/*Ejercicio 6*/
select u.idUsr, u.nombreUsr, COUNT(v.idVid) as cantVideosSubidos
from Usuario u, Video v
where u.idUsr = v.idUsr and v.fechaPublicacionVid between '2023-01-01' and '2023-12-31'
group by u.idUsr, u.nombreUsr
order by cantVideosSubidos DESC;

/*Ejercicio 7*/
select top 1 t.idTec, t.nombreTec , SUM(v.nroMeGusta) as MasMeGusta
from Tecnologia t, Video v
where t.idTec = v.idTec
	  and v.fechaPublicacionVid between '2022-01-03' and '2022-07-31'
group by t.idTec, t.nombreTec
order by sum(v.nroMeGusta) DESC;

/*Ejercicio 8*/
update Video
set nroMeGusta = nroMeGusta + 1
where idVid = 33;

/*Ejercicio 9*/
delete from Video
where duracion < 666;