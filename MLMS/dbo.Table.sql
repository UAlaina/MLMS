CREATE TABLE Book
(
	bookId INT NOT NULL PRIMARY KEY,
	bookName VARCHAR(125),
	ISBNNo INT,
	author VARCHAR(125),
	publishDate DATE,
	edition VARCHAR(125),
	Descriptions TEXT
);
