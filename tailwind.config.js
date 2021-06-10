const colors = require('tailwindcss/colors')
module.exports = {
  mode:  'jit',
  purge: [
    "src/SAFEwind.Client/public/**/*.html",
    "src/SAFEwind.Client/src/**/*.{js,jsx,ts,tsx,vue}"
  ],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {

      colors: {
          bgray: colors.coolGray,
          wgray: colors.warmGray,
          lime: colors.lime

      },
    },
  },
  variants: {
    extend: {},
  },
  plugins: [],
}
