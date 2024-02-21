mod person;
use person::{Person, PersonType};
use postgres::Error as PostgresError;
use std::{
    fs,
    io::{prelude::*, BufReader},
    net::{TcpListener, TcpStream},
};

fn main() {
    // This code will listen at the local address 127.0.0.1:7878 for incoming TCP streams.
    // When it gets an incoming stream, it will print "Connections established!".
    let listener = TcpListener::bind(format!("127.0.0.1:9000")).unwrap();
    println!("Server listening on port 9000");
    // bind works like the new function, returning a new TcpListener instance.

    // The incoming method on TcpLinterner return an iterator that gives us a sequence of streams (more specifically, streams of type TcpStream).
    // A single stream represents an open connection between the client and the server.
    // The server generates a response, and the server closes the connection.
    // As such, we will read from the TcpStream to see what the client sent and then write our response to the stream to send data back to the client.
    for stream in listener.incoming() {
        let stream = stream.unwrap();

        handle_connection(stream);
    }
}

// In this function we'll read data from TCP stream and print it so we can see the data being sent from the browser.

fn handle_connection(mut stream: TcpStream) {
    let buf_reader = BufReader::new(&mut stream);
    let request_line = buf_reader.lines().next().unwrap().unwrap();

    let (status_line, filename) = if request_line == "GET / HTTP/1.1" {
        ("HTTP/1.1 200 OK", "hello.html")
    } else {
        ("HTTP/1.1 404 NOT FOUND", "404.html")
    };

    let contents = fs::read_to_string(filename).unwrap();
    let length = contents.len();

    let response = format!("{status_line}\r\nContent-Length: {length}\r\n\r\n{contents}");

    stream.write_all(response.as_bytes()).unwrap();
}