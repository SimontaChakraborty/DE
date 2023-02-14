select * from X;

select sum(X) from X where X>=0 Union 
select sum(X) from X where X<0
