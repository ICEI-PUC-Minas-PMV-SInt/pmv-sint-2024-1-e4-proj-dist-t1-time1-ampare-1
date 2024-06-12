import { Box, Card, CardMedia, Paper } from "@mui/material"

import DESTAQUE from "../assets/banner-readme.png"

export const Home = () => {
    return (
        <Box display={"flex"} alignContent={"center"} justifyContent={"center"} >


            <img alt="Imagem de Destaque" src={DESTAQUE} />

        </Box >
    )
}