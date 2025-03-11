import Header from "./components/Header";
import '@mantine/core/styles.css'

import { ColorSchemeScript, MantineProvider, mantineHtmlProps } from "@mantine/core";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en" {...mantineHtmlProps}>
      <head>
        <ColorSchemeScript />
      </head>
      <body>
        <MantineProvider>
          <Header/>
          {children}
        </MantineProvider>
      </body>
    </html>
  )
}