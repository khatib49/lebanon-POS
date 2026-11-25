import { defineConfig } from 'vitest/config'
import react from '@vitejs/plugin-react'
import tailwindcss from '@tailwindcss/vite'
import { VitePWA } from 'vite-plugin-pwa'

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    react(),
    tailwindcss(),
    VitePWA({
      registerType: 'autoUpdate',
      manifest: {
        name: 'lebanon-POS',
        short_name: 'lebanon-POS',
        description: 'Point of sale in dollars and lira, with or without internet',
        theme_color: '#12302a',
        background_color: '#12302a',
        display: 'standalone',
        start_url: '/',
        icons: [{ src: '/icon.svg', sizes: 'any', type: 'image/svg+xml', purpose: 'any' }],
      },
    }),
  ],
  server: {
    proxy: { '/api': 'http://localhost:5080' },
  },
  test: { environment: 'node' },
})
