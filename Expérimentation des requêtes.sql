SELECT * 
FROM bachelor 
WHERE 		idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND 
            idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND 
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND 
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1
ORDER BY numberOfLikes DESC;

// 5 intérêts en commun
SELECT * 
FROM bachelor 
WHERE 		(idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND 
            idbrands = (SELECT idbrands FROM bachelor WHERE id = 1)) AND 
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND 
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1 AND
			id NOT IN (
                SELECT id
				FROM bachelor 
				WHERE 		idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND 
            				idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND 
							idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
							idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
							idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND 
							idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
							id != 1 )
ORDER BY numberOfLikes DESC;

// Chercher les utilisateurs qui a au moins 1 intérêt en commun excluant la personne en question
SELECT * 
FROM bachelor 
WHERE 		(idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) OR 
            idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) OR 
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) OR 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) OR 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) OR 
			idsports = (SELECT idsports FROM bachelor WHERE id = 1)) AND 
			id != 1
ORDER BY numberOfLikes DESC;

// Exactement les 6 intérêts en commun
SELECT * 
FROM bachelor 
WHERE 		idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
            idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1
ORDER BY numberOfLikes DESC;

// Exactement 5 intérêts en commun sans compter le livre
SELECT * 
FROM bachelor 
WHERE 		
            idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1 AND
            id NOT IN (                
                SELECT id 
				FROM bachelor 
				WHERE 		
                	idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
            		idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
					idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
					idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
					idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
					idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
					id != 1
			)
ORDER BY numberOfLikes DESC;

// Exactement 5 intérêts en commun sans compter la marque
SELECT * 
FROM bachelor 
WHERE 		
            idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1 AND
            id NOT IN (                
                SELECT id 
				FROM bachelor 
				WHERE 		
                	idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
            		idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
					idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
					idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
					idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
					idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
					id != 1
			)
ORDER BY numberOfLikes DESC;

// Exactement 5 intérêts en commun sans compter le hobbie
SELECT * 
FROM bachelor 
WHERE 		
            idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
			idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1 AND
            id NOT IN (                
                SELECT id 
				FROM bachelor 
				WHERE 		
                	idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
            		idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
					idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
					idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
					idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
					idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
					id != 1
			)
ORDER BY numberOfLikes DESC;

// Exactement 5 intérêts en commun sans compter le film
SELECT * 
FROM bachelor 
WHERE 		
            idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
			idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1 AND
            id NOT IN (                
                SELECT id 
				FROM bachelor 
				WHERE 		
                	idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
            		idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
					idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
					idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
					idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
					idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
					id != 1
			)
ORDER BY numberOfLikes DESC;

// Exactement 5 intérêts en commun sans compter la music
SELECT * 
FROM bachelor 
WHERE 		
            idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
			idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND
			idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
			id != 1 AND
            id NOT IN (                
                SELECT id 
				FROM bachelor 
				WHERE 		
                	idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
            		idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
					idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
					idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
					idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
					idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
					id != 1
			)
ORDER BY numberOfLikes DESC;

// Exactement 5 intérêts en commun sans compter le sport
SELECT * 
FROM bachelor 
WHERE 		
            idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
			idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
			idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
			idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND
			idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND 
			id != 1 AND
            id NOT IN (                
                SELECT id 
				FROM bachelor 
				WHERE 		
                	idbookgenres = (SELECT idbookgenres FROM bachelor WHERE id = 1) AND
            		idbrands = (SELECT idbrands FROM bachelor WHERE id = 1) AND
					idhobbies = (SELECT idhobbies FROM bachelor WHERE id = 1) AND 
					idmoviegenres = (SELECT idmoviegenres FROM bachelor WHERE id = 1) AND 
					idmusicgenres = (SELECT idmusicgenres FROM bachelor WHERE id = 1) AND
					idsports = (SELECT idsports FROM bachelor WHERE id = 1) AND 
					id != 1
			)
ORDER BY numberOfLikes DESC;