
drop trigger if exists bi_partida;
drop trigger if exists bi_partida_Aforo;
drop trigger if exists bi_partida_No_Aloja_En;
drop trigger if exists bu_partida;
drop trigger if exists bu_partida_Aforo;

-- No se pueden vender mas entradas que el aforo de la sala

-- En la misma partida el jugadorNegras no puede ser tambien jugadorBlanca



-- El arbitro no puede ser de la misma nacionalidad de los jugadores de cada partida que esta arbitrando
create trigger bi_partida before insert on partida
	for each row
	when (select pais from participante where nSocio = new.arbitro) in 
		(select pais from participante where nSocio = new.jugadorBlancas or nSocio = new.jugadorNegras)
	begin
		signal sqlstate '45000' set mysql_errno = 5000, message_text = 'El nacionalidad del arbitro coincide con el de los jugadores';
	end;
	
create trigger bi_partida_Aforo before insert on partida
for each row
when (select capacidado from sala where codS = new.sala) < new.entradasVendidas
begin
	signal sqlstate '45000' set mysql_errno = 5502, message_text = 'Aforo superado';
end;

create trigger bi_partida_No_Aloja_En before insert on partida
for each row
when (select hotel from sala where codS = new.sala) in (select nombreHotel from aloja) 
	and exists (select * from aloja where new.arbitro = nSocio and new.jugadorBlancas = nSocio and new.jugadorNegras = nSocio)
begin
	signal sqlstate '45000' set mysql_errno = 5503, message_text = 'Operación no permitida';
end;

create trigger bu_partida before update on partida
	for each row
	when (select pais from participante where nSocio = new.arbitro) in 
		(select pais from participante where nSocio = new.jugadorBlancas or nSocio = new.jugadorNegras)
	begin
		signal sqlstate '45000' set mysql_errno = 5000, message_text = 'El nacionalidad del arbitro coincide con el de los jugadores';
	end;

create trigger bu_partida_Aforo before update on partida
for each row
when (select capacidad from sala where codS = new.sala) < new.entradasVendidas
begin
		signal sqlstate '45000' set mysql_errno = 5502, message_text = 'Aforo superado';
end;