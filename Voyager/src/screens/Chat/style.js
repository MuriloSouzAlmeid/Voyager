import styled from "styled-components";
import { InputCadastarViagem } from "../../components/Comps/style";

export const ContainerChat = styled.View`
    height: 100%;
    width: 100%;
    padding: 16% 5% 20px;
    align-items: center;
    background-color: white;
    gap: 20px;
`

export const BotaoVoltarStyle = styled.TouchableOpacity`
    position: absolute;
    left: 4%;
    top: 10%;
    height: 35px;
    width: 35px;
    z-index: 10;
`

export const HeaderChat = styled.View`
    flex-direction: row;
    width: 75%;
    justify-content: space-between;
    align-items: center;
    height: 80px;
`

export const PontoHeader = styled.Text`
    font-size: 48px;
    text-align: center;
    font-family: "LouisGeorgeCafe-Bold";
    height: 100%;
`

export const LogoVoyager = styled.Image`
    height: 77px;
    width: 92px;
`

export const LogoGemini = styled.Image`
    height: 40px;
    width: 106px;
`

export const ChatSectionBox = styled.ScrollView`
    width: 100%;
    border: 1px solid black;
    margin-bottom: 70px;
    overflow-y: hidden;
    /* justify-content: center;
    align-items: center; */
`

export const InputPromptStyle = styled(InputCadastarViagem)`
    width: 345px;
    padding: 0 20px;
`