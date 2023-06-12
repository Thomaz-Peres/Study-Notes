from flask import Flask, render_template, request

# __name__ refers to the current file. And so this is just a little trickj that says turn this file into a Flask application
app = Flask(__name__)

@app.route("/", methods=["GET", "POST"])
def index():
    if request.method == "GET":
        return render_template("index.html")
    elif request.method == "POST":
        return render_template("greet.html", name=request.form.get("name", "world"))