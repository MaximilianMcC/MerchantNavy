# Merchant navy trading game
A strategy game that takes inspiration from chartered trading companies such as the V.O.C., and the East India Trading Company during the age of sail (1500-1800)

## How the localisations work
- The 'main'/fallback file has `superauto` at the start of the file
- All other children link their super to a specific one: `super=en`. If a key isnt in this particular language then it will fallback to whatever is used in the `en` language.
- The first line, `[0]`, MUST be the super stuff ONLY. No comments or spaces or anything
- Comments are with a `#`
- Keys and stuff are given like: `name=bob`, then in code it's like `lang["name"]`
- Keys are to be in PascalCase, and `super` as-well as `superauto` are valid keys
- You can use an `=` sign in a value unescaped but not in a key
- The language file names need to match the things in the super stuff btw