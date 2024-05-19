require("dotenv").config();
const express = require("express");
const app = express();
const mongoose = require("mongoose");
const cors = require("cors");

const Game = require("./models/Game");

app.use(cors());
app.use(express.json());
app.use(express.urlencoded({ extended: true }));

app.get("/jatekKiir", async (req, res) => {
  try {
    const adat = await Game.find({});
    res.status(200).json({ adat });
  } catch (error) {
    res.status(400).json({ msg: "Valami hiba történt: " + error.message });
  }
});

app.post("/jatekHozzad", async (req, res) => {
  try {
    const { kategoria, cim, ar, megjelenes } = req.body;
    console.log(req.body);
    const newGame = new Game({
      kategoria,
      cim,
      ar,
      megjelenes,
    });
    await newGame.save();

    res
      .status(200)
      .json({ msg: "Az adatok sikeresen feltöltésre kerültek az adatbázisba" });
  } catch (error) {
    res.status(400).json({ msg: "Valami hiba történt: " + error.message });
  }
});

app.delete("/torol", async (req, res) => {
  try {
    const body = req.body;
    const toroltAdat = await Festival.findOneAndDelete({
      _id: body.item,
    }).exec();
    if (toroltAdat) {
      res.status(200).json({ msg: "Sikeres adat törlés!" });
    } else {
      res.status(404).json({ msg: "A felhasználó nem található!" });
    }
  } catch (error) {
    res.status(500).json({ msg: "Valami hiba történt!" });
  }
});

const port = process.env.PORT || 3500;

mongoose
  .connect(process.env.MONGO_URI)
  .then(() => {
    console.log("Sikeres adatbázis csatlakozás");
  })
  .catch((error) => {
    console.log("Valami hiba történt" + error);
  });

app.listen(port, () => {
  console.log(`http://localhost:${port}`);
});
