/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.vue",
    "./src/**/**/*.vue",
  ],
  theme: {
    extend: {},
  },
  plugins: [
    
    require('postcss-import'),
    // require('tailwindcss/nesting')(require('postcss-nesting')),
    require('tailwindcss'),
    require('autoprefixer'),
  ],
}
