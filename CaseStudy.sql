
create database virtualartgallery

-- create the artists table
create table artists(
artistid int primary key,
name varchar(100) not null,
biography varchar(max) null,
birthdate date null,
nationality varchar(50) null,
website varchar(200) null,
contactinformation varchar(max) null
)


-- create the artworks table
create table artworks(
artworkid int primary key,
title varchar(100) not null,
description varchar(max) null,
creationdate date null,
medium varchar(50) null,
imageurl varchar(200) null,
artistid int not null,
foreign key (artistid) references artists(artistid)
)

select * from artworks
-- create the users table
create table users(
userid int primary key,
username varchar(50) not null unique,
password varchar(255) not null,
email varchar(100) not null unique,
firstname varchar(50) not null,
lastname varchar(50) not null,
dateofbirth date null,
profilepicture varchar(200) null
)

-- create the galleries table
create table galleries(
galleryid int primary key,
name varchar(100) not null,
description varchar(max) null,
location varchar(200) null,
curatorid int not null,
openinghours varchar(100) null,
foreign key (curatorid) references artists(artistid)
)

-- create the user_favorite_artwork junction table
create table user_favorite_artwork(
userid int not null,
artworkid int not null,
primary key (userid, artworkid),
foreign key (userid) references users(userid),
foreign key (artworkid) references artworks(artworkid)
)

-- create the artwork_gallery junction table
create table artwork_gallery(
artworkid int not null,
galleryid int not null,
primary key (artworkid, galleryid),
foreign key (artworkid) references artworks(artworkid),
foreign key (galleryid) references galleries(galleryid)
)

-- Insert 10 records into the artists table
insert into artists (artistid, name, biography, birthdate, nationality, website, contactinformation) 
values 
(1, 'Raja Ravi Varma', 'One of the greatest painters in Indian history, known for depictions of mythology', '1848-04-29', 'Indian', 'https://www.rajaravivarma.com', 'ravi_varma@example.com'),
(2, 'M.F. Husain', 'Indian modernist painter famous for bold, vibrant paintings', '1915-09-17', 'Indian', 'https://www.mfhusain.com', 'mfhusain@example.com'),
(3, 'Amrita Sher-Gil', 'Indian-Hungarian painter, part of India’s modern art movement', '1913-01-30', 'Indian', 'https://www.amritashergil.com', 'amrita_shergil@example.com'),
(4, 'Jamini Roy', 'Known for his folk art style', '1887-04-11', 'Indian', 'https://www.jaminiroy.com', 'jamini_roy@example.com'),
(5, 'Tyeb Mehta', 'Celebrated painter and filmmaker, known for Expressionism', '1925-07-26', 'Indian', 'https://www.tyebmehta.com', 'tyeb_mehta@example.com'),
(6, 'Rabin Mondal', 'Artist known for figurative Expressionism', '1929-10-09', 'Indian', 'https://www.rabinmondal.com', 'rabin_mondal@example.com'),
(7, 'Bhupen Khakhar', 'Painter with narrative, autobiographical style', '1934-03-10', 'Indian', 'https://www.bhupenkhakhar.com', 'bhupen_khakhar@example.com'),
(8, 'Anjolie Ela Menon', 'Contemporary painter known for vibrant colors', '1940-07-17', 'Indian', 'https://www.anjoliemenon.com', 'anjolie_menon@example.com'),
(9, 'Subodh Gupta', 'Sculptor and installation artist', '1964-12-05', 'Indian', 'https://www.subodhgupta.com', 'subodh_gupta@example.com'),
(10, 'Jogen Chowdhury', 'Famous for figurative art', '1939-02-19', 'Indian', 'https://www.jogenchowdhury.com', 'jogen_chowdhury@example.com');

-- Insert 10 records into the artworks table
insert into artworks (artworkid, title, description, creationdate, medium, imageurl, artistid) 
values 
(1, 'Shakuntala', 'Depicting a scene from Mahabharata', '1870-01-01', 'Oil on canvas', 'shakuntala.jpg', 1),
(2, 'Horses', 'Bold painting of horses by M.F. Husain', '1965-02-15', 'Acrylic', 'horses.jpg', 2),
(3, 'Three Girls', 'Portrait of three women by Amrita Sher-Gil', '1935-05-01', 'Oil on canvas', 'three_girls.jpg', 3),
(4, 'Mother and Child', 'Folk painting by Jamini Roy', '1940-06-01', 'Tempera on paper', 'mother_child.jpg', 4),
(5, 'Kali', 'Depiction of goddess Kali by Tyeb Mehta', '1989-11-12', 'Oil on canvas', 'kali.jpg', 5),
(6, 'The King', 'Portrait of a monarch by Rabin Mondal', '1973-09-10', 'Acrylic on canvas', 'the_king.jpg', 6),
(7, 'You Can’t Please All', 'Narrative painting by Bhupen Khakhar', '1981-07-18', 'Oil on canvas', 'cant_please_all.jpg', 7),
(8, 'Portrait of a Young Woman', 'A vibrant portrait by Anjolie Ela Menon', '1986-04-24', 'Oil on masonite', 'young_woman.jpg', 8),
(9, 'Vessels', 'Sculpture by Subodh Gupta', '2004-09-19', 'Sculpture', 'vessels.jpg', 9),
(10, 'The Blue Pot', 'Still life by Jogen Chowdhury', '1998-02-20', 'Ink and watercolor', 'blue_pot.jpg', 10);

-- Insert 10 records into the users table
insert into users (userid, username, password, email, firstname, lastname, dateofbirth, profilepicture) 
values 
(1, 'manan_ch', 'securepass', 'manan@example.com', 'Manan', 'Chhikara', '1999-05-10', 'manan_pic.jpg'),
(2, 'artlover_india', 'mypassword123', 'artlover_india@example.com', 'Raj', 'Patel', '1992-08-15', 'raj_patel.jpg'),
(3, 'gallery_curator', 'curator123', 'curator_india@example.com', 'Neha', 'Singh', '1985-12-05', 'neha_singh.jpg'),
(4, 'ravi_kumar', 'securepass1', 'ravi_kumar@example.com', 'Ravi', 'Kumar', '1990-11-20', 'ravi_kumar.jpg'),
(5, 'deepa_art', 'mypassword456', 'deepa_art@example.com', 'Deepa', 'Mehta', '1993-02-22', 'deepa_mehta.jpg'),
(6, 'modern_artist', 'artistpass', 'modern_artist@example.com', 'Anil', 'Sharma', '1988-07-14', 'anil_sharma.jpg'),
(7, 'classic_art_lover', 'artpass321', 'classic_art_lover@example.com', 'Suman', 'Verma', '1987-06-03', 'suman_verma.jpg'),
(8, 'neha_mishra', 'neha123', 'neha_mishra@example.com', 'Neha', 'Mishra', '1995-09-11', 'neha_mishra.jpg'),
(9, 'priya_gallery', 'gallerypass', 'priya_gallery@example.com', 'Priya', 'Kapoor', '1989-12-25', 'priya_kapoor.jpg'),
(10, 'vishal_painter', 'vishalart', 'vishal_painter@example.com', 'Vishal', 'Patel', '1991-10-08', 'vishal_patel.jpg');

-- Insert 10 records into the galleries table
insert into galleries (galleryid, name, description, location, curatorid, openinghours) 
values 
(1, 'Indian Heritage Art Gallery', 'Featuring India’s historical and cultural art', 'Mumbai, India', 1, '09:00-17:00'),
(2, 'Modern Indian Art Gallery', 'Showcasing contemporary Indian art', 'Delhi, India', 2, '10:00-18:00'),
(3, 'Amrita Sher-Gil Gallery', 'Dedicated to Amrita Sher-Gil’s works', 'Kolkata, India', 3, '08:00-16:00'),
(4, 'Jamini Roy Gallery', 'Folk art of Jamini Roy', 'Kolkata, India', 4, '10:00-17:00'),
(5, 'Tyeb Mehta Collection', 'Tyeb Mehta’s works on display', 'Mumbai, India', 5, '11:00-18:00'),
(6, 'Rabin Mondal Art Space', 'Expressionist works by Rabin Mondal', 'Chennai, India', 6, '09:30-16:30'),
(7, 'Bhupen Khakhar Museum', 'Narrative art by Bhupen Khakhar', 'Ahmedabad, India', 7, '09:00-17:00'),
(8, 'Anjolie Menon Art Studio', 'Exhibition of Anjolie Ela Menon’s work', 'Bangalore, India', 8, '10:00-18:00'),
(9, 'Subodh Gupta Installations', 'Sculptures and installations by Subodh Gupta', 'Delhi, India', 9, '08:30-16:30'),
(10, 'Jogen Chowdhury Gallery', 'Jogen Chowdhury’s figurative works', 'Hyderabad, India', 10, '09:00-18:00');

-- Insert 10 records into the user_favorite_artwork table
insert into user_favorite_artwork (userid, artworkid) 
values 
(1, 1), 
(2, 2), 
(3, 3), 
(4, 4), 
(5, 5), 
(6, 6), 
(7, 7), 
(8, 8), 
(9, 9), 
(10, 10);

-- Insert 10 records into the artwork_gallery table
insert into artwork_gallery (artworkid, galleryid) 
values 
(1, 1),  
(2, 2),  
(3, 3),  
(4, 4),  
(5, 5),  
(6, 6),  
(7, 7),  
(8, 8),  
(9, 9),  
(10, 10);

