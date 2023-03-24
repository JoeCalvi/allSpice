CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

DROP TABLE IF EXISTS accounts;

DELETE FROM
accounts
WHERE id = "";

CREATE TABLE IF NOT EXISTS recipes(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
  creatorId VARCHAR(255) NOT NULL COMMENT 'Recipe Creator Id',
  title VARCHAR(80) NOT NULL COMMENT 'Recipe Title',
  instructions VARCHAR(1000) NOT NULL COMMENT 'Recipe Instructions',
  img VARCHAR(500) NOT NULL COMMENT 'Recipe Image',
  category VARCHAR(50) NOT NULL COMMENT 'Recipe Category',

  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

DROP TABLE recipes;

INSERT INTO recipes
(title, instructions, img, category, `creatorId`)
VALUES
('Delicious Pasta', 'Make the pasta it\'s not that hard.', 'https://food.fnr.sndimg.com/content/dam/images/food/fullset/2021/02/05/Baked-Feta-Pasta-4_s4x3.jpg.rend.hgtvcom.616.493.suffix/1615916524567.jpeg', 'Pasta', '641b636bc53b98bd6be93ce2');

CREATE TABLE IF NOT EXISTS ingredients(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Ingredient Id',
  recipeId INT NOT NULL COMMENT 'Recipe Id',
  name VARCHAR(80) NOT NULL COMMENT 'Ingredient Name',
  quantity VARCHAR(80) NOT NULL COMMENT 'Ingredient Quantity',

  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO ingredients
(recipeId, name, quantity)
VALUES
('1', 'Paprika', '2 tsp');

DROP TABLE IF EXISTS ingredients;

CREATE TABLE IF NOT EXISTS favorites(
  id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'Favorite Id',
  accountId VARCHAR(255) NOT NULL COMMENT 'Account Id',
  recipeId INT NOT NULL COMMENT 'Recipe Id',

  FOREIGN KEY (accountId) REFERENCES accounts(id) ON DELETE CASCADE,
  FOREIGN KEY (recipeId) REFERENCES recipes(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

INSERT INTO favorites
(accountId, recipeId)
VALUES
('641b636bc53b98bd6be93ce2', '1');

DROP TABLE IF EXISTS favorites;