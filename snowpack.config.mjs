// Snowpack Configuration File
// See all supported options: https://www.snowpack.dev/reference/configuration

/** @type {import("snowpack").SnowpackUserConfig } */
import proxy from 'http2-proxy';

export default  {
  mount: {
    /* ... */
    "src/SAFEwind.Client/public": "/",
    "src/SAFEwind.Client/src" : "/_dist_"
  },
  plugins: [
    /* ... */
    '@snowpack/plugin-react-refresh',
    '@snowpack/plugin-dotenv',
    '@snowpack/plugin-postcss',
    '@snowpack/plugin-typescript',
    '@jadex/snowpack-plugin-tailwindcss-jit' //temp fix for spack/jit issue
  ],
  packageOptions: {
    /* ... */
  },
  devOptions: {
    /* ... */
    tailwindConfig: './tailwind.config.js',
  },
  buildOptions: {
    /* ... */
  },
  routes: [
      {
        src: '/api/*/.*',
        dest: (req, res) => {

            return proxy.web(req, res, {
                hostname: 'localhost',
                port: 8085,
            });
        }
      },

      {
        src: '/socket/*',  //pattern might not be right, need *?
        upgrade: (req, socket, head) => {

            const defaultWSHandler = (err, req, socket, head) => {
              if (err) {
                console.error('proxy error', err);
                socket.destroy();
              }
            };

            proxy.ws(
              req,
              socket,
              head,
              {
                hostname: 'localhost',
                port: 8085,
              },
              defaultWSHandler,
            );
          },
       },

  ]
};
