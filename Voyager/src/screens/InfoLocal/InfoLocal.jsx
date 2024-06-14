import { StatusBar } from "react-native";
import { TitleDefault } from "../../components/Text/style";
import { ContainerInfoLocal, LocalMapBox } from "./style";

export const InfoLocal = ({ navigation }) => {
  return (
    <ContainerInfoLocal>
      <StatusBar barStyle={"dark-content"} translucent={true} backgroundColor={"#8531C6"} />

      <LocalMapBox>
        <TitleDefault>Componente de Mapa da Expo</TitleDefault>
      </LocalMapBox>
    </ContainerInfoLocal>
  );
};
