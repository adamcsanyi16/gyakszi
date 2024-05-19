const mongoose = require("mongoose");

const gameSchema = new mongoose.Schema({
  kategoria: {
    type: String,
  },
  cim: {
    type: String,
  },
  ar: {
    type: Number,
  },
  megjelenes: {
    type: Date,
  },
});

module.exports = mongoose.model("game", gameSchema);
