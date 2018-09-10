module.exports = {
  env: {
    browser: true
  },
  extends: ["airbnb", "plugin:prettier/recommended"],
  parser: "babel-eslint",
  rules: {
    "react/jsx-filename-extension": [
      "error",
      {
        extensions: [".js", ".jsx"]
      }
    ],
    "react/prefer-stateless-function": [2, { ignorePureComponents: true }],
    "linebreak-style": 0,
    "prettier/prettier": "error"
  }
};
